import { TOOLTIP_SELECTOR } from "../constants/components-constant.js";

export function initializeTooltips() {
    const tooltipTriggerElements = document.querySelectorAll(TOOLTIP_SELECTOR);
    const tooltips = [];

    tooltipTriggerElements.forEach((element) => {
        const tooltip = new bootstrap.Tooltip(element);
        tooltips.push(tooltip);

        // Ensure tooltip hides when mouse leaves
        element.addEventListener("mouseleave", () => tooltip.hide());
    });

    return tooltips;
}