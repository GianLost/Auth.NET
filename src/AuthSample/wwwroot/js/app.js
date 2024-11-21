import { initializeDarkMode } from "./dark-mode/dark-mode.js";

import { form } from "./forms/form.js";
import { FormHandler } from "./forms/validation/validate-form.js";

import { initializeAlert } from "./components/alert.js";
import { initializeTogglePassword } from "./animation/toggle-password-visibility.js";
import { initializeTooltips } from "./components/tooltip.js";

// app initialize
document.addEventListener('DOMContentLoaded', () => {

    initializeDarkMode();

    form.initialize();
    FormHandler.initialize();

    initializeAlert();
    initializeTogglePassword();
    initializeTooltips();
});