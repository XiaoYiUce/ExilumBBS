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

/**
 * 滚动到指定元素处
 * @param {string} elementId 目标元素ID
 */
export function scrollToIdContainer(elementId) {
    if (!elementId) {
        console.warn('scrollToIdContainer: elementId is required');
        return;
    }

    // 获取目标元素
    const element = document.getElementById(elementId);

    if (!element) {
        console.warn(`scrollToIdContainer: Element with id "${elementId}" not found`);
        return;
    }

    // 平滑滚动到元素位置
    element.scrollIntoView({
        behavior: 'smooth',  // 平滑滚动
        block: 'start',      // 元素顶部对齐视口顶部
        inline: 'nearest'    // 水平方向最近对齐（通常不需要水平滚动）
    });
}