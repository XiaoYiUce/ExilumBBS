using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Utils
{
    public static class QuillInterop
    {
        #region Constants

        private const string strCreateQuill = "QuillFunctions.createQuill";
        private const string strGetText = "QuillFunctions.getQuillText";
        private const string strGetHTML = "QuillFunctions.getQuillHTML";
        private const string strGetContent = "QuillFunctions.getQuillContent";
        private const string strLoadQuillContent = "QuillFunctions.loadQuillContent";
        private const string strEnableQuillEditor = "QuillFunctions.enableQuillEditor";
        private const string strInsertImage = "QuillFunctions.insertQuillImage";
        private const string strInsertEmoji = "QuillFunctions.insertQuillEmoji";
        private const string strFocusToEnd = "QuillFunctions.quillFocusToEnd";
        private const string strQuillFocus = "QuillFunctions.focusQuill";
        private const string strSetQuillFontSize = "QuillFunctions.setQuillFontSize";
        private const string strSetQuillHeaderSize = "QuillFunctions.setQuillHeaderSize";
        private const string strSetLineHeightSize = "QuillFunctions.setLineHeightSize";
        private const string strInsertDivider = "QuillFunctions.insertDivider";

        #endregion Constants

        /// <summary>
        /// Creates the quill.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        /// <param name="quillElement">The quill element.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        /// <param name="placeholder">The placeholder.</param>
        /// <param name="theme">The theme.</param>
        /// <param name="debugLevel">The debug level.</param>
        /// <returns>ValueTask&lt;System.Object&gt;.</returns>
        internal static ValueTask<object> CreateQuill(
            IJSRuntime jsRuntime,
            ElementReference quillElement,
            bool readOnly,
            string placeholder,
            string theme,
            string debugLevel,
            bool enabledToolbar,
            ElementReference? toolbarElement = null)
        {
            if (enabledToolbar == false)
            {
                return jsRuntime.InvokeAsync<object>(
                    strCreateQuill,
                    quillElement, readOnly,
                    placeholder, theme, debugLevel, false);
            }
            else
            {
                return jsRuntime.InvokeAsync<object>(
                    strCreateQuill,
                    quillElement, readOnly,
                    placeholder, theme, debugLevel, true, toolbarElement);
            }

        }

        /// <summary>
        /// Creates the quill.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        /// <param name="placeholder">The placeholder.</param>
        /// <param name="theme">The theme.</param>
        /// <param name="debugLevel">The debug level.</param>
        /// <returns>ValueTask&lt;System.Object&gt;.</returns>
        internal static ValueTask<object> CreateQuill(
            IJSRuntime jsRuntime,
            string quillId,
            bool readOnly,
            string placeholder,
            string theme,
            string debugLevel,
            bool enabledToolbar)
        {
            if (enabledToolbar == false)
            {
                return jsRuntime.InvokeAsync<object>(
                    strCreateQuill, quillId, readOnly,
                    placeholder, theme, debugLevel, false);
            }
            else
            {
                return jsRuntime.InvokeAsync<object>(
                    strCreateQuill, quillId, readOnly,
                    placeholder, theme, debugLevel, true);
            }

        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        /// <param name="quillElement">The quill element.</param>
        /// <returns>ValueTask&lt;System.String&gt;.</returns>
        internal static ValueTask<string> GetText(
            IJSRuntime jsRuntime,
            ElementReference quillElement)
        {
            return jsRuntime.InvokeAsync<string>(
                strGetText,
                quillElement);
        }

        /// <summary>
        /// Gets the HTML.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        /// <param name="quillElement">The quill element.</param>
        /// <returns>ValueTask&lt;System.String&gt;.</returns>
        internal static ValueTask<string> GetHTML(
            IJSRuntime jsRuntime,
            ElementReference quillElement)
        {
            return jsRuntime.InvokeAsync<string>(
                strGetHTML,
                quillElement);
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        /// <param name="quillElement">The quill element.</param>
        /// <returns>ValueTask&lt;System.String&gt;.</returns>
        internal static ValueTask<string> GetContent(
            IJSRuntime jsRuntime,
            ElementReference quillElement)
        {
            return jsRuntime.InvokeAsync<string>(
                strGetContent,
                quillElement);
        }

        /// <summary>
        /// Loads the content of the quill.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        /// <param name="quillElement">The quill element.</param>
        /// <param name="Content">The content.</param>
        /// <returns>ValueTask&lt;System.Object&gt;.</returns>
        internal static ValueTask<object> LoadQuillContent(
            IJSRuntime jsRuntime,
            ElementReference quillElement,
            string Content)
        {
            return jsRuntime.InvokeAsync<object>(
                strLoadQuillContent,
                quillElement, Content);
        }

        /// <summary>
        /// Enables the quill editor.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        /// <param name="quillElement">The quill element.</param>
        /// <param name="mode">if set to <c>true</c> [mode].</param>
        /// <returns>ValueTask&lt;System.Object&gt;.</returns>
        internal static ValueTask<object> EnableQuillEditor(
            IJSRuntime jsRuntime,
            ElementReference quillElement,
            bool mode)
        {
            return jsRuntime.InvokeAsync<object>(
                strEnableQuillEditor,
                quillElement, mode);
        }

        internal static ValueTask<object> InsertQuillImage(
            IJSRuntime jsRuntime,
            ElementReference quillElement,
            string imageURL)
        {
            return jsRuntime.InvokeAsync<object>(
                strInsertImage,
                quillElement, imageURL);
        }

        internal static ValueTask<object> InsertQuillEmoji(
            IJSRuntime jsRuntime,
            ElementReference quillElement,
            string imageURL)
        {
            return jsRuntime.InvokeAsync<object>(
                strInsertEmoji,
                quillElement, imageURL);
        }

        internal static ValueTask<object> FocusToEnd(
            IJSRuntime jsRuntime,
            ElementReference quillElement)
        {
            return jsRuntime.InvokeAsync<object>(
                strFocusToEnd, quillElement);
        }

        internal static ValueTask<object> FocusQuill(
            IJSRuntime jsRuntime,
            ElementReference quillElement)
        {
            return jsRuntime.InvokeAsync<object>(
                strQuillFocus, quillElement);
        }

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="quillElement">Quill编辑器元素</param>
        /// <param name="fontSize">字体大小</param>
        /// <returns></returns>
        internal static ValueTask<object> SetFontSize(
            IJSRuntime jsRuntime,
            ElementReference quillElement,
            string fontSize)
        {
            return jsRuntime.InvokeAsync<object>(strSetQuillFontSize, quillElement, fontSize);
        }

        /// <summary>
        /// 设置标题大小
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="quillElement"></param>
        /// <param name="headerSize"></param>
        /// <returns></returns>
        internal static ValueTask<object> SetHeaderSize(
            IJSRuntime jsRuntime,
            ElementReference quillElement,
            string headerSize)
        {
            return headerSize switch
            {
                "H1" => jsRuntime.InvokeAsync<object>(strSetQuillHeaderSize, quillElement, 1),
                "H2" => jsRuntime.InvokeAsync<object>(strSetQuillHeaderSize, quillElement, 2),
                "H3" => jsRuntime.InvokeAsync<object>(strSetQuillHeaderSize, quillElement, 3),
                "H4" => jsRuntime.InvokeAsync<object>(strSetQuillHeaderSize, quillElement, 4),
                "H5" => jsRuntime.InvokeAsync<object>(strSetQuillHeaderSize, quillElement, 5),
                "H6" => jsRuntime.InvokeAsync<object>(strSetQuillHeaderSize, quillElement, 6),
                _ => jsRuntime.InvokeAsync<object>(strSetQuillHeaderSize, quillElement, false)
            };
        }

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="quillElement">Quill编辑器元素</param>
        /// <param name="lineHeight">行高</param>
        /// <returns></returns>
        internal static ValueTask<object> SetLineHeight(
            IJSRuntime jsRuntime,
            ElementReference quillElement,
            string lineHeight)
        {
            if (lineHeight == "默认")
            {
                return jsRuntime.InvokeAsync<object>(strSetLineHeightSize, quillElement, "");
            }

            return jsRuntime.InvokeAsync<object>(strSetLineHeightSize, quillElement, lineHeight);
        }

        /// <summary>
        /// 插入分割线
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="quillElement"></param>
        /// <returns></returns>
        internal static ValueTask<object> InsertDivider(
            IJSRuntime jsRuntime,
            ElementReference quillElement)
        {
            return jsRuntime.InvokeAsync<object>(strInsertDivider, quillElement);
        }
    }
}
