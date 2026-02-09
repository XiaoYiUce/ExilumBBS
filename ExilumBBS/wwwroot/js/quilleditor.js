(function () {
    const Block = Quill.import('blots/block/embed');
    const fontSize = ['10px', '13px', '16px', '18px', '24px', '32px', '48px']
    const defaultToolbarContainer = [
        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
        ['bold'],
        [{ 'size': fontSize }],
        ['italic', 'underline', 'strike'],
        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
        [{ 'color': [] }, { 'background': [] }],
        [{ 'align': [] }],
        ['clean']
    ]

    class ExtendedImage extends Block {
        static create(value) {
            const node = super.create();
            if (typeof value === 'string') {
                // 兼容旧格式：纯字符串 URL
                node.setAttribute('src', value);
            } else {
                // 新格式：{ url, class, alt, ... }
                node.setAttribute('src', value.url || '');
                if (value.class) {
                    node.classList.add(...value.class.split(' '));
                }
                if (value.alt) {
                    node.setAttribute('alt', value.alt);
                }
                // 可扩展其他属性，如 style, data-* 等
            }
            return node;
        }

        static value(node) {
            return {
                url: node.getAttribute('src'),
                class: node.className || '',
                alt: node.getAttribute('alt') || ''
            };
        }
    }

    ExtendedImage.blotName = 'extendedImage';
    ExtendedImage.tagName = 'img';
    Quill.register(ExtendedImage);

    Quill.imports['attributors/style/size'].whitelist = fontSize;
    Quill.register(Quill.imports['attributors/style/size']);

    window.QuillFunctions = {
        createQuill: function (
            quillElement, readOnly,
            placeholder, theme, debugLevel, toolbar) {

            var options = {
                debug: debugLevel,
                modules: {
                },
                placeholder: placeholder,
                readOnly: readOnly,
                theme: theme
            };

            if (toolbar === false || toolbar == null) {
                options.modules.toolbar = false;
            } else if (toolbar === true) {
                // 启用默认 toolbar（Quill 默认的完整工具栏）
                let toolbarConfig = {
                    container: defaultToolbarContainer,
                    handlers: {}
                };

                options.modules.toolbar = toolbarConfig;
            } else {
                // 自定义 toolbar 配置（数组或对象）
                options.modules.toolbar = toolbar;
            }

            var quill = new Quill(quillElement, options);
            quillElement.__quill = quill;
        },

        getQuillContent: function (quillElement) {
            return JSON.stringify(quillElement.__quill.getContents());
        },

        getQuillText: function (quillElement) {
            return quillElement.__quill.getText();
        },

        getQuillHTML: function (quillElement) {
            return quillElement.__quill.root.innerHTML;
        },

        loadQuillContent: function (quillElement, quillContent) {
            var content = JSON.parse(quillContent);
            return quillElement.__quill.setContents(content, 'api');
        },

        enableQuillEditor: function (quillElement, mode) {
            quillElement.__quill.enable(mode);
        },

        // 通用插入图片方法（支持 class）
        _insertExtendedImage: function (quill, index, imageUrl, attributes) {
            var Delta = Quill.import('delta');
            var insertValue = typeof imageUrl === 'string'
                ? { url: imageUrl }
                : imageUrl;

            // 合并用户传入的属性（如 class, alt）
            if (attributes) {
                insertValue = { ...insertValue, ...attributes };
            }

            return quill.updateContents(
                new Delta()
                    .retain(index)
                    .insert({ extendedImage: insertValue })
            );
        },
        insertQuillImage: function (quillElement, imageURL) {
            var quill = quillElement.__quill;
            var editorIndex = quill.getLength();
            return this._insertExtendedImage(quill, editorIndex, imageURL, {
                class: "showImg"
            });
        },
        insertQuillEmoji: function (quillElement, emojiURL, altText = '') {
            var quill = quillElement.__quill;
            var editorIndex = quill.getSelection() ? quill.getSelection().index : 0;
            var newIndex = this._insertExtendedImage(quill, editorIndex, emojiURL, {
                class: 'emoji',
                alt: altText
            });
            quill.setSelection(editorIndex + 1);
            return newIndex;
        },
        quillFocusToEnd: function (quillElement) {
            var quill = quillElement.__quill;
            if (quill) {
                // 获取当前内容长度（即末尾位置）
                const length = quill.getLength();
                // 设置光标到末尾
                quill.setSelection(length, 0);
                // 聚焦编辑器
                quill.focus();
            }
        },
        focusQuill: function (element) {
            const quill = element.__quill;
            if (quill) {
                quill.focus();
            }
        },
    };
})();