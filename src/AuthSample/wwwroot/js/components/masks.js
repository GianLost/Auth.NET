import { PHONE_INPUT_SELECTOR, PHONE_MASK_REGEX, PHONE_SPLIT_REGEX } from "../constants/components-constant.js";

// Function to format phone numbers with BR mask
export function formatPhoneNumber(value) {
    const cleanedValue = value.replace(/\D/g, ""); // Remove all non-digit characters

    // Apply mask: (XX) XXXXX-XXXX
    let maskedValue = cleanedValue.replace(PHONE_MASK_REGEX, "($1) $2");
    maskedValue = maskedValue.replace(PHONE_SPLIT_REGEX, "$1-$2");

    return maskedValue;
}

// Event handler to apply the phone mask on input events
export function applyPhoneMask(event) {
    const input = event.target;
    input.value = formatPhoneNumber(input.value);
}

// Function to initialize phone mask for all inputs
export function initializePhoneMask() {
    const phoneInputs = document.querySelectorAll(PHONE_INPUT_SELECTOR);

    // Attach the input event listener to each field
    phoneInputs.forEach((input) => {
        input.addEventListener("input", applyPhoneMask);
    });
}

// Initialize the phone mask when DOM is ready
document.addEventListener("DOMContentLoaded", initializePhoneMask);