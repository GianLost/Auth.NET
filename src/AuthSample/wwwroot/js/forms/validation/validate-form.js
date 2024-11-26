// validate-form.js
import encryptData from '../cryptography/data-crypt.js';
import { VALIDATION_RULES, MESSAGES, ENCRYPTION_KEYS, CSS_CLASSES } from "../../constants/components-constant.js";
import { initializePhoneMask } from '../../components/masks.js';

const FormValidator = {
    validateInputDynamically(input) {
        const validationRules = (input.dataset.validationRules || '').split(',').map(rule => rule.trim());
        const feedbackDiv = input.parentElement.querySelector('.invalid-tooltip');
        let errorMessage = '';

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
                        errorMessage = input.dataset.errorMessage || `Requires at least ${minLength} characters!`;
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

        if (errorMessage) {
            this.showValidationError(input, feedbackDiv, errorMessage);
        } else {
            this.showValidationSuccess(input, feedbackDiv);
        }
    },

    showValidationError(input, feedbackDiv, errorMessage) {
        input.classList.add(CSS_CLASSES.INVALID);
        input.classList.remove(CSS_CLASSES.VALID);
        feedbackDiv.textContent = errorMessage;
        feedbackDiv.style.display = 'block';
    },

    showValidationSuccess(input, feedbackDiv) {
        input.classList.remove(CSS_CLASSES.INVALID);
        input.classList.add(CSS_CLASSES.VALID);
        feedbackDiv.textContent = '';
        feedbackDiv.style.display = 'none';

        if (feedbackDiv.textContent.trim() === '') {
            feedbackDiv.style.display = 'none';
        }
    },

    clearErrorMessages(form) {
        form.querySelectorAll('.invalid-tooltip').forEach(div => {
            div.textContent = '';
            div.style.display = 'none';
        });
    }
};

const FormHandler = {
    async handleFormSubmit(event) {
        event.preventDefault();
        const form = event.target;
        const inputs = form.querySelectorAll('input:not([type=hidden])');
        let firstInvalidInput = null;
        let isFormValid = true;

        inputs.forEach(input => {
            FormValidator.validateInputDynamically(input);
            if (input.classList.contains(CSS_CLASSES.INVALID) && !firstInvalidInput) {
                firstInvalidInput = input;
                isFormValid = false;
            }
        });

        if (!isFormValid) {
            firstInvalidInput.focus();
        } else {
            let formData = {};
            inputs.forEach(input => {
                formData[input.name] = input.value;
            });

            const encryptedData = await encryptData(formData, ENCRYPTION_KEYS.KEY, ENCRYPTION_KEYS.IV);

            let encryptedInput = form.querySelector('input[name="userEncrypted"]');
            if (!encryptedInput) {
                encryptedInput = document.createElement('input');
                encryptedInput.type = 'hidden';
                encryptedInput.name = 'userEncrypted';
                form.appendChild(encryptedInput);
            }

            encryptedInput.value = encryptedData;
            inputs.forEach(input => input.disabled = true);
            form.submit();
        }
    },

    initializeFormValidation(form) {
        form.addEventListener('submit', this.handleFormSubmit.bind(this));
        form.querySelectorAll('input').forEach(input => {
            input.addEventListener('input', () => FormValidator.validateInputDynamically(input));
            input.addEventListener('focus', () => {
                FormValidator.clearErrorMessages(form);
                const feedbackDiv = input.parentElement.querySelector('.invalid-tooltip');
                FormValidator.validateInputDynamically(input);
                if (input.classList.contains(CSS_CLASSES.INVALID)) {
                    FormValidator.showValidationError(input, feedbackDiv, feedbackDiv.textContent);
                }
            });

            if (input.getAttribute('type') === 'tel') {
                input.addEventListener('input', initializePhoneMask);
            }
        });
    },

    initialize() {
        document.querySelectorAll('.invalid-tooltip').forEach(div => {
            if (div.textContent.trim() === '') {
                div.style.display = 'none';
                div.classList.add(CSS_CLASSES.HIDDEN);
            }
        });

        document.querySelectorAll('.needs-validation').forEach(form => {
            this.initializeFormValidation(form);
        });

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

// Exportando os objetos para uso em outros arquivos
export { FormHandler, FormValidator };