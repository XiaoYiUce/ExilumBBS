(function () {
    var Parchment = Quill.import('parchment');

    class ExtendedImage extends Parchment.Embed {
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

    window.QuillFunctions = {
        createQuill: function (
            quillElement, readOnly,
            placeholder, theme, debugLevel) {

            var options = {
                debug: debugLevel,
                modules: {
                    toolbar: false
                },
                placeholder: placeholder,
                readOnly: readOnly,
                theme: theme
            };

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
            var editorIndex = quill.getSelection() ? quill.getSelection().index : 0;
            return this._insertExtendedImage(quill, editorIndex, imageURL);
        },
        insertQuillEmoji: function (quillElement, emojiURL, altText = '') {
            var quill = quillElement.__quill;
            var editorIndex = quill.getSelection() ? quill.getSelection().index : 0;
            return this._insertExtendedImage(quill, editorIndex, emojiURL, {
                class: 'emoji',
                alt: altText
            });
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
        }
    };
})();