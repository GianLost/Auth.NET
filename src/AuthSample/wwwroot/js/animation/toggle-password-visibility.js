import { loginPasswordInput, loginTogglePasswordButton } from "../constants/components-constant.js";

// Function to handle dynamic password visibility
function handlePasswordVisibility(event, isVisible) {
    const toggleButton = $(event.currentTarget);
    const passwordInput = toggleButton.siblings(loginPasswordInput);

    if (!passwordInput.length) return;

    // Toggle password visibility and update icon
    passwordInput.attr("type", isVisible ? "text" : "password");
    toggleButton
        .toggleClass("bi-eye-fill", isVisible)
        .toggleClass("bi-eye-slash-fill", !isVisible);
}

// Initialize the event listeners
function initializeTogglePassword() {
    loginTogglePasswordButton.on("mousedown touchstart", function (event) {
        handlePasswordVisibility(event, true);
    });

    loginTogglePasswordButton.on("mouseup touchend mouseleave", function (event) {
        handlePasswordVisibility(event, false);
    });
}

// Export the initialization function
export { initializeTogglePassword };