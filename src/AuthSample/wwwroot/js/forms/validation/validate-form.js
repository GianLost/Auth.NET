//import { encryptData } from '../cryptography/dataCrypt.js';
import { applyPhoneMask } from '../../components/masks.js';

// Constants for validation rules
const VALIDATION_RULES = {
    REQUIRED: 'required',
    MIN_LENGTH: 'min-length',
    PATTERN: 'pattern',
    CONFIRM_EMAIL: 'confirm-email',
    CONFIRM_PASSWORD: 'confirm-password',
};

// Constants for error messages
const MESSAGES = {
    REQUIRED: 'This field is required !',
    INVALID_FORMAT: 'Invalid format field !',
    EMAIL_MISMATCH: 'The emails are different !',
    PASSWORD_MISMATCH: 'The passwords are different !'
};

// Constants for encryption keys
const ENCRYPTION_KEYS = {
    KEY: new TextEncoder().encode("character-key0@55YssY??-&&36A9W="),
    IV: new TextEncoder().encode("char-iv1=Key00?#"),
};

// FormValidator object responsible for validating form fields
const FormValidator = {
    // Function to dynamically validate an input field
    validateInputDynamically(input) {
        // Get the validation rules from the input's dataset
        const validationRules = (input.dataset.validationRules || '').split(',').map(rule => rule.trim());
        const feedbackDiv = input.parentElement.querySelector('.invalid-tooltip');
        let errorMessage = '';

        // Iterate over the validation rules and check each one
        validationRules.some(rule => {
            switch (rule) {
                case VALIDATION_RULES.REQUIRED:
                    if (input.value.trim() === '') {
                        errorMessage = feedbackDiv.textContent.trim() || MESSAGES.REQUIRED;
                    }
                    break;
                case VALIDATION_RULES.MIN_LENGTH:
                    const minLength = parseInt(input.dataset.minLength, 10);
                    if (input.value.trim().length < minLength) {
                        errorMessage = input.dataset.errorMessage || `Requires at least ${minLength} characters !`;
                    }
                    break;
                case VALIDATION_RULES.PATTERN:
                    const pattern = new RegExp(input.dataset.pattern);
                    if (!pattern.test(input.value.trim())) {
                        errorMessage = input.dataset.errorMessage || MESSAGES.INVALID_FORMAT;
                    }
                    break;
                case VALIDATION_RULES.CONFIRM_EMAIL:
                    const emailField = document.getElementById(input.dataset.confirmEmailFor);
                    if (emailField && emailField.value.trim() !== '' && input.value.trim() !== emailField.value.trim()) {
                        errorMessage = MESSAGES.EMAIL_MISMATCH;
                    }
                    break;
                case VALIDATION_RULES.CONFIRM_PASSWORD:
                    const passwordField = document.getElementById(input.dataset.confirmPasswordFor);
                    if (passwordField && passwordField.value.trim() !== '' && input.value.trim() !== passwordField.value.trim()) {
                        errorMessage = MESSAGES.PASSWORD_MISMATCH;
                    }
                    break;
            }
            return !!errorMessage;
        });

        // Display the error or success message based on validation result
        if (errorMessage) {
            this.showValidationError(input, feedbackDiv, errorMessage);
        } else {
            this.showValidationSuccess(input, feedbackDiv);
        }
    },

    // Function to show an error message
    showValidationError(input, feedbackDiv, errorMessage) {
        input.classList.add('is-invalid');
        input.classList.remove('is-valid');
        feedbackDiv.textContent = errorMessage;
        feedbackDiv.style.display = 'block';
    },

    // Function to show validation success
    showValidationSuccess(input, feedbackDiv) {
        input.classList.remove('is-invalid');
        input.classList.add('is-valid');
        feedbackDiv.textContent = '';
        feedbackDiv.style.display = 'none';

        // Add this block to remove the div if it is empty
        if (feedbackDiv.textContent.trim() === '') {
            feedbackDiv.style.display = 'none';
        }
    },

    // Function to clear all error messages
    clearErrorMessages(form) {
        form.querySelectorAll('.invalid-tooltip').forEach(div => {
            div.textContent = '';
            div.style.display = 'none';
        });
    }
};

// FormHandler object responsible for form manipulation and submission
const FormHandler = {
    // Function to handle form submission
    async handleFormSubmit(event) {
        event.preventDefault();

        const form = event.target;
        const inputs = form.querySelectorAll('input:not([type=hidden])');

        let firstInvalidInput = null;
        let isFormValid = true;

        // Validate each input dynamically
        inputs.forEach(input => {
            FormValidator.validateInputDynamically(input);
            if (input.classList.contains('is-invalid') && !firstInvalidInput) {
                firstInvalidInput = input;
                isFormValid = false;
            }
        });

        // If any field is invalid, prevent submission and focus on the first invalid field
        if (!isFormValid) {
            firstInvalidInput.focus();
        } else {
            // If the form is valid, encrypt the data and submit it
            let formData = {};
            inputs.forEach(input => {
                formData[input.name] = input.value;
            });

            // Encrypt the form data
            const encryptedData = await encryptData(formData, ENCRYPTION_KEYS.KEY, ENCRYPTION_KEYS.IV);

            // Create a hidden input field to store the encrypted data
            let encryptedInput = form.querySelector('input[name="userEncrypted"]');
            if (!encryptedInput) {
                encryptedInput = document.createElement('input');
                encryptedInput.type = 'hidden';
                encryptedInput.name = 'userEncrypted';
                form.appendChild(encryptedInput);
            }

            encryptedInput.value = encryptedData;

            // Disable the original fields to prevent sending unencrypted data
            inputs.forEach(input => input.disabled = true);

            // Submit the form
            form.submit();
        }
    },

    // Function to initialize form validation
    initializeFormValidation(form) {
        form.addEventListener('submit', this.handleFormSubmit.bind(this));
        form.querySelectorAll('input').forEach(input => {
            input.addEventListener('input', () => FormValidator.validateInputDynamically(input));
            input.addEventListener('focus', () => {
                FormValidator.clearErrorMessages(form);
                const feedbackDiv = input.parentElement.querySelector('.invalid-tooltip');
                FormValidator.validateInputDynamically(input);
                if (input.classList.contains('is-invalid')) {
                    FormValidator.showValidationError(input, feedbackDiv, feedbackDiv.textContent);
                }
            });
            // Apply phone mask if the input type is 'tel'
            if (input.getAttribute('type') === 'tel') {
                input.addEventListener('input', applyPhoneMask);
            }
        });
    },

    // Function to initialize validation for all forms on the page
    initialize() {

        // Hide all empty .invalid-tooltip divs when the page loads
        document.querySelectorAll('.invalid-tooltip').forEach(div => {
            if (div.textContent.trim() === '') {
                div.style.display = 'none';
                div.classList.add('hidden');
            }
        });

        document.querySelectorAll('.needs-validation').forEach(form => {
            this.initializeFormValidation(form);
        });

        // Add input events to email fields and confirm email fields to validate dynamically
        document.querySelectorAll('input[type="email"]').forEach(input => {
            const confirmInput = document.getElementById(input.dataset.confirmEmailFor);
            if (confirmInput) {
                input.addEventListener('input', () => {
                    if (confirmInput.value.trim() !== '') {
                        FormValidator.validateInputDynamically(confirmInput);
                    }
                });
                confirmInput.addEventListener('input', () => {
                    if (input.value.trim() !== '') {
                        FormValidator.validateInputDynamically(input);
                    }
                });
            }
        });

        // Add input events to password fields and confirm password fields to validate dynamically
        document.querySelectorAll('input[type="password"]').forEach(input => {
            const confirmInput = document.getElementById(input.dataset.confirmPasswordFor);
            if (confirmInput) {
                input.addEventListener('input', () => {
                    if (confirmInput.value.trim() !== '') {
                        FormValidator.validateInputDynamically(confirmInput);
                    }
                });
                confirmInput.addEventListener('input', () => {
                    if (input.value.trim() !== '') {
                        FormValidator.validateInputDynamically(input);
                    }
                });
            }
        });
    }
};

// Initialize form validation for all forms once the DOM is fully loaded
document.addEventListener('DOMContentLoaded', () => {
    FormHandler.initialize();
});