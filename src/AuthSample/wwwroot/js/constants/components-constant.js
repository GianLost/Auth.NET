// File responsible for containing all constants declarations for using animation functions

// const forms
export const loginPasswordInput = $(".input-password");
export const loginTogglePasswordButton = $(".toggle-password");

// Validation rules constants
export const VALIDATION_RULES = {
    REQUIRED: 'required',
    MIN_LENGTH: 'min-length',
    PATTERN: 'pattern',
    CONFIRM_EMAIL: 'confirm-email',
    CONFIRM_PASSWORD: 'confirm-password',
};

// error message constants
export const MESSAGES = {
    REQUIRED: 'This field is required!',
    INVALID_FORMAT: 'Invalid format field!',
    EMAIL_MISMATCH: 'The emails are different!',
    PASSWORD_MISMATCH: 'The passwords are different!'
};

// encryption keys
export const ENCRYPTION_KEYS = {
    KEY: new TextEncoder().encode("character-key0@55YssY??-&&36A9W="),
    IV: new TextEncoder().encode("char-iv1=Key00?#"),
};

// css class constants for validation feedback
export const CSS_CLASSES = {
    INVALID: 'is-invalid',
    VALID: 'is-valid',
    HIDDEN: 'hidden',
};

// Label styles constants
export const LABEL_STYLES = {
    DEFAULT: {
        top: '50%',
        left: '1rem',
        fontSize: '1.1rem',
        fontWeight: 'normal',
        backgroundColor: 'transparent',
        padding: '0'
    },
    ACTIVE: {
        top: '0.05rem',
        left: '0.6rem',
        fontSize: '0.8rem',
        fontWeight: '500',
        padding: '0.35rem',
        backgroundColor: '#fff',
        borderRadius: '3px',
        transition: 'all 0.13s linear'
    }
};

// Class selectors for form inputs and labels
export const SELECTORS = {
    FORM_GROUP_INPUT: '.form-group input'
};

// const alerts
export const alert = $(".alert");
export const closeButton = $(".close-alert");

// const phone mask
export const PHONE_INPUT_SELECTOR = "input[type='tel']";
export const PHONE_MASK_REGEX = /(\d{2})(\d)/;
export const PHONE_SPLIT_REGEX = /(\d{4,5})(\d{4})$/;

//const tooltip
export const TOOLTIP_SELECTOR = "[data-bs-toggle='tooltip']";

// const theme
export const BODY = document.body;
export const THEME_TOGGLE_BUTTON = $('.theme-toggle');
export const THEME_STORAGE_KEY = 'theme';
export const DARK_MODE_CLASS = 'darkmode';
export const LIGHT_MODE_CLASS = 'lightmode';