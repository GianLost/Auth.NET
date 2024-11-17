import { loginPasswordInput, loginTogglePasswordButton } from "../constants/components-constant.js";

function togglePasswordVisibility() {
    const toggleButtons = $(loginTogglePasswordButton);

    toggleButtons.on('mousedown touchstart', function () {
        const toggleButton = $(this);
        const passwordInput = toggleButton.siblings(loginPasswordInput);
        passwordInput.attr('type', 'text');
        toggleButton.removeClass('bi-eye-slash-fill').addClass('bi-eye-fill');
    });

    toggleButtons.on('mouseup touchend mouseleave', function () {
        const toggleButton = $(this);
        const passwordInput = toggleButton.siblings(loginPasswordInput);
        passwordInput.attr('type', 'password');
        toggleButton.removeClass('bi-eye-fill').addClass('bi-eye-slash-fill');
    });
}

$(() => {
    togglePasswordVisibility();
});