'use strict';

document.addEventListener('DOMContentLoaded', function () {
    const EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    const firstName       = document.getElementById('Input_FirstName');
    const lastName        = document.getElementById('Input_LastName');
    const phoneNumber     = document.getElementById('Input_PhoneNumber');
    const email           = document.getElementById('Input_Email');
    const password        = document.getElementById('Input_Password');
    const confirmPassword = document.getElementById('Input_ConfirmPassword');

    const MIN_FIRST_NAME = parseInt(firstName.dataset.valLengthMin);
    const MAX_FIRST_NAME = parseInt(firstName.dataset.valLengthMax);
    const MIN_LAST_NAME  = parseInt(lastName.dataset.valLengthMin);
    const MAX_LAST_NAME  = parseInt(lastName.dataset.valLengthMax);
    const MIN_PASSWORD   = parseInt(password.dataset.valLengthMin);
    const PASSWORD_REGEX = new RegExp(password.dataset.valRegexPattern);

    const MSG = {
        firstNameRequired: firstName.dataset.valRequired,
        firstNameLength:   firstName.dataset.valLength,
        lastNameRequired:  lastName.dataset.valRequired,
        lastNameLength:    lastName.dataset.valLength,
        phoneRequired:     phoneNumber.dataset.valRequired,
        emailRequired:     email.dataset.valRequired,
        emailInvalid:      email.dataset.valEmail,
        passwordRequired:  password.dataset.valRequired,
        passwordLength:    password.dataset.valLength,
        passwordInvalid:   password.dataset.valRegex,
        confirmRequired:   confirmPassword.dataset.valRequired,
        passwordMismatch:  confirmPassword.dataset.valEqualto,
    };

    const form = document.getElementById('registerForm');

    function errorSpan(modelPath) {
        return document.querySelector(`[data-valmsg-for="${modelPath}"]`);
    }

    const spans = {
        firstName:       errorSpan('Input.FirstName'),
        lastName:        errorSpan('Input.LastName'),
        phoneNumber:     errorSpan('Input.PhoneNumber'),
        email:           errorSpan('Input.Email'),
        password:        errorSpan('Input.Password'),
        confirmPassword: errorSpan('Input.ConfirmPassword'),
    };

    function showError(field, span, message) {
        span.textContent = message;
        field.classList.add('is-invalid');
    }

    function clearError(field, span) {
        span.textContent = '';
        field.classList.remove('is-invalid');
    }

    // --- Validation rules — each returns an error string or null ---

    function validateFirstName() {
        const val = firstName.value.trim();
        if (!val) return MSG.firstNameRequired;
        if (val.length < MIN_FIRST_NAME || val.length > MAX_FIRST_NAME) return MSG.firstNameLength;
        return null;
    }

    function validateLastName() {
        const val = lastName.value.trim();
        if (!val) return MSG.lastNameRequired;
        if (val.length < MIN_LAST_NAME || val.length > MAX_LAST_NAME) return MSG.lastNameLength;
        return null;
    }

    function validatePhoneNumber() {
        if (!phoneNumber.value.trim()) return MSG.phoneRequired;
        return null;
    }

    function validateEmail() {
        const val = email.value.trim();
        if (!val) return MSG.emailRequired;
        if (!EMAIL_REGEX.test(val)) return MSG.emailInvalid;
        return null;
    }

    function validatePassword() {
        const val = password.value;
        if (!val) return MSG.passwordRequired;
        if (val.length < MIN_PASSWORD) return MSG.passwordLength;
        if (!PASSWORD_REGEX.test(val)) return MSG.passwordInvalid;
        return null;
    }

    function validateConfirmPassword() {
        const val = confirmPassword.value;
        if (!val) return MSG.confirmRequired;
        if (val !== password.value) return MSG.passwordMismatch;
        return null;
    }

    const validations = [
        { field: firstName,       span: spans.firstName,       validate: validateFirstName },
        { field: lastName,        span: spans.lastName,        validate: validateLastName },
        { field: phoneNumber,     span: spans.phoneNumber,     validate: validatePhoneNumber },
        { field: email,           span: spans.email,           validate: validateEmail },
        { field: password,        span: spans.password,        validate: validatePassword },
        { field: confirmPassword, span: spans.confirmPassword, validate: validateConfirmPassword },
    ];

    function runValidation(v) {
        const error = v.validate();
        if (error) {
            showError(v.field, v.span, error);
            return false;
        }
        clearError(v.field, v.span);
        return true;
    }

    // Silently strip any character that isn't a digit or + as the user types
    phoneNumber.addEventListener('input', function () {
        const filtered = this.value.replace(/[^\d+]/g, '');
        if (filtered !== this.value) this.value = filtered;
    });

    // Show error on blur; while typing, only clear the error — never show a new one.
    // This prevents format/length errors from appearing mid-input after a required error.
    validations.forEach(function (v) {
        v.field.addEventListener('blur', function () {
            runValidation(v);
        });

        v.field.addEventListener('input', function () {
            if (v.field.classList.contains('is-invalid')) {
                clearError(v.field, v.span);
            }
        });
    });

    // When password changes, clear the confirm mismatch only if they now match
    password.addEventListener('input', function () {
        if (confirmPassword.classList.contains('is-invalid')) {
            if (!validateConfirmPassword()) clearError(confirmPassword, spans.confirmPassword);
        }
    });

    // On submit: validate everything, block submission if anything fails
    form.addEventListener('submit', function (e) {
        const allValid = validations.map(runValidation).every(Boolean);

        if (!allValid) {
            e.preventDefault();

            const firstInvalid = form.querySelector('.is-invalid');
            if (firstInvalid) {
                firstInvalid.scrollIntoView({ behavior: 'smooth', block: 'center' });
                firstInvalid.focus();
            }
        }
    });
});
