import { alert, closeButton } from "../constants/components-constant.js";

const ALERT_SHOW_CLASS = "show";
const ALERT_HIDE_CLASS = "hide";
const ALERT_TRANSITION_DURATION = 500; // Transition duration in milliseconds
const ALERT_INITIAL_DELAY = 100; // Initial delay to show alert

// Function to show alert with transition
export function showAlert() {
    setTimeout(() => {
        alert.addClass(ALERT_SHOW_CLASS).removeClass(ALERT_HIDE_CLASS);
    }, ALERT_INITIAL_DELAY);
}

// Function to hide alert with transition
export function hideAlert() {
    alert.addClass(ALERT_HIDE_CLASS).removeClass(ALERT_SHOW_CLASS);

    // Remove alert from DOM after transition
    setTimeout(() => {
        alert.hide(); // Hides the alert
    }, ALERT_TRANSITION_DURATION);
}

// Function to initialize alert behavior
export function initializeAlert() {
    // Using jQuery to attach event listener for close button
    closeButton.on("click", hideAlert);

    // Show the alert
    showAlert();
}

// Ensure the alert is initialized after the DOM content is loaded
$(() => {
    initializeAlert();
});