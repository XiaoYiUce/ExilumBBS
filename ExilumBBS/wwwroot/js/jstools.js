/**
 * 获取指定元素的滚动位置
 * @param {string} elementId - 元素的 ID（如 'scrollContainer'）
 * @returns 滚动位置
 */
export function getScrollPosition(elementId) {
    const el = document.getElementById(elementId);
    if (!el) {
        console.warn(`Element with id ' $ {elementId}' not found.`);
        return 0;
    }
    return el.scrollTop;
}

/**
 * 设置指定元素的滚动位置
 * @param {string} elementId - 元素的 ID
 * @param {number} top - 垂直滚动位置
 */
export function setScrollPosition(elementId, top) {
    const el = document.getElementById(elementId);
    if (el) {
        el.scrollTop = top ?? el.scrollTop;
    } else {
        console.warn(`Element with id ' $ {elementId}' not found.`);
    }
}