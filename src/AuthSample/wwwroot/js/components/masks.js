// Function to apply BR mask to telephone fields
export function applyPhoneMask(event) {
    const input = event.target;
    let phoneNumber = input.value.replace(/\D/g, '');

    // Apply mask (XX) XXXXX-XXXX
    phoneNumber = phoneNumber.replace(/(\d{2})(\d)/, '($1) $2');
    phoneNumber = phoneNumber.replace(/(\d{4,5})(\d{4})$/, '$1-$2');

    input.value = phoneNumber;
}

// Selects all inputs of type 'tel'
const phoneInputs = document.querySelectorAll('input[type="tel"]');

// Add the input event to each of them
phoneInputs.forEach(input => {
    input.addEventListener('input', applyPhoneMask);
});