(function () {
    const BlockEmbed = Quill.import('blots/block/embed');
    const Parchment = Quill.import('parchment')
    const fontSize = ['10px', '13px', '16px', '18px', '24px', '32px', '48px']
    const lineHeight = ['', '1', '1.15', '1.6', '2', '2.5', '3'];

    // 默认工具栏容器
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

    // 插入行高format
    class lineHeightAttributor extends Parchment.StyleAttributor { }

    const lineHeightStyle = new lineHeightAttributor(
        'lineHeight',
        'line-height',
        {
            scope: Parchment.Scope.Block,
            whitelist: lineHeight
        }
    )
    Quill.register({ 'formats/lineHeight': lineHeightStyle }, true)

    // 插入自定义的分割线模块
    class DividerBlot extends BlockEmbed {
        static create() {
            return document.createElement('hr');
        }

        length() {
            return 1;
        }

        static value() {
            return true;
        }
    }
    DividerBlot.tagName = 'hr';
    DividerBlot.blotName = 'divider';
    Quill.register(DividerBlot);

    // 自定义图像插入
    class ExtendedImage extends BlockEmbed {
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

    // 注册自定义项
    Quill.register(ExtendedImage);

    // 注册自定义字体大小
    Quill.imports['attributors/style/size'].whitelist = fontSize;
    Quill.register(Quill.imports['attributors/style/size']);
    Quill.register({
        'modules/table-better': QuillTableBetter
    }, true);

    window.QuillFunctions = {
        createQuill: function (
            quillElement, readOnly,
            placeholder, theme, debugLevel, toolbar, toolbarElement) {

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
            }
            else {
                // 启用默认 toolbar（Quill 默认的完整工具栏）
                let toolbarConfig = {
                    container: toolbarElement.childNodes.length == 0 ? defaultToolbarContainer : toolbarElement,
                    handlers: {}
                };

                options.modules.toolbar = toolbarConfig;
                options.modules['table-better'] = {
                    language: 'zh_CN',
                    menus: ['column', 'row', 'delete'],
                    toolbarTable: true
                };
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
        focusQuill: function (quillElement) {
            const quill = quillElement.__quill;
            if (quill) {
                quill.focus();
            }
        },
        setQuillFontSize: function (quillElement, size) {
            const quill = quillElement.__quill;
            if (quill) {
                quill.format('size', size);
            }
        },
        setQuillHeaderSize: function (quillElement, size) {
            const quill = quillElement.__quill;
            if (quill) {
                quill.format('header', size);
            }
        },
        setLineHeightSize: function (quillElement, size) {
            const quill = quillElement.__quill;
            if (quill) {
                quill.format('lineHeight', size);
            }
        },
        insertDivider: function (quillElement) {
            var quill = quillElement.__quill;
            var Delta = Quill.import('delta');
            var index = quill.getSelection() ? quill.getSelection().index : 0;
            var newIndex = quill.updateContents(
                new Delta()
                    .retain(index)
                    .insert({ divider: true })
                    .insert('\n')
            );
            quill.setSelection(index + 2);
            return newIndex;
        }
    };
})();