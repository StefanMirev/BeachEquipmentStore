'use strict';

document.addEventListener('DOMContentLoaded', function () {
    const EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    const firstName       = document.getElementById('FirstName');
    const lastName        = document.getElementById('LastName');
    const phoneNumber     = document.getElementById('PhoneNumber');
    const email           = document.getElementById('Email');
    const password        = document.getElementById('Password');
    const confirmPassword = document.getElementById('ConfirmPassword');
    const passwordHint    = document.getElementById('passwordHint');

    const MIN_FIRST_NAME = parseInt(firstName.dataset.valLengthMin);
    const MAX_FIRST_NAME = parseInt(firstName.dataset.valLengthMax);
    const MIN_LAST_NAME  = parseInt(lastName.dataset.valLengthMin);
    const MAX_LAST_NAME  = parseInt(lastName.dataset.valLengthMax);
    const MIN_PHONE      = parseInt(phoneNumber.dataset.valLengthMin);
    const MAX_PHONE      = parseInt(phoneNumber.dataset.valLengthMax);
    const MIN_PASSWORD   = parseInt(password.dataset.valLengthMin);
    const PASSWORD_REGEX = new RegExp(password.dataset.valRegexPattern);

    const MSG = {
        firstNameRequired: firstName.dataset.valRequired,
        firstNameLength:   firstName.dataset.valLength,
        lastNameRequired:  lastName.dataset.valRequired,
        lastNameLength:    lastName.dataset.valLength,
        phoneRequired:     phoneNumber.dataset.valRequired,
        phoneLength:       phoneNumber.dataset.valLength,
        emailRequired:     email.dataset.valRequired,
        emailInvalid:      email.dataset.valEmail,
        passwordRequired:  password.dataset.valRequired,
        passwordLength:    password.dataset.valLength,
        passwordInvalid:   password.dataset.valRegex,
        passwordMismatch:  confirmPassword.dataset.valEqualto,
    };

    const form = document.getElementById('registerForm');

    function errorSpan(fieldName) {
        return document.querySelector(`[data-valmsg-for="${fieldName}"]`);
    }

    const spans = {
        firstName:       errorSpan('FirstName'),
        lastName:        errorSpan('LastName'),
        phoneNumber:     errorSpan('PhoneNumber'),
        email:           errorSpan('Email'),
        password:        errorSpan('Password'),
        confirmPassword: errorSpan('ConfirmPassword'),
    };

    function showError(field, span, message, hint) {
        span.textContent = message;
        field.classList.add('is-invalid');
        if (hint) hint.style.display = 'none';
    }

    function clearError(field, span, hint) {
        span.textContent = '';
        field.classList.remove('is-invalid');
        if (hint) hint.style.display = '';
    }

    // --- Validation rules ---

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
        const val = phoneNumber.value.trim();
        if (!val) return MSG.phoneRequired;
        if (val.length < MIN_PHONE || val.length > MAX_PHONE) return MSG.phoneLength;
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
        // Treat empty confirm as mismatch when password has a value; both empty = required
        if (!confirmPassword.value && !password.value) return null;
        if (confirmPassword.value !== password.value) return MSG.passwordMismatch;
        return null;
    }

    const validations = [
        { field: firstName,       span: spans.firstName,       validate: validateFirstName },
        { field: lastName,        span: spans.lastName,        validate: validateLastName },
        { field: phoneNumber,     span: spans.phoneNumber,     validate: validatePhoneNumber },
        { field: email,           span: spans.email,           validate: validateEmail },
        { field: password,        span: spans.password,        validate: validatePassword, hint: passwordHint },
        { field: confirmPassword, span: spans.confirmPassword, validate: validateConfirmPassword },
    ];

    function runValidation(v) {
        const error = v.validate();
        if (error) {
            showError(v.field, v.span, error, v.hint);
            return false;
        }
        clearError(v.field, v.span, v.hint);
        return true;
    }

    // Silently strip any character that isn't a digit or + as the user types
    phoneNumber.addEventListener('input', function () {
        const filtered = this.value.replace(/[^\d+]/g, '');
        if (filtered !== this.value) this.value = filtered;
    });

    const confirmEntry = validations.find(function (v) { return v.field === confirmPassword; });

    // All fields except confirm password: show error on blur, clear on input when already invalid
    validations.forEach(function (v) {
        if (v.field === confirmPassword) return;

        v.field.addEventListener('blur', function () {
            runValidation(v);
        });

        v.field.addEventListener('input', function () {
            if (v.field.classList.contains('is-invalid')) {
                clearError(v.field, v.span, v.hint);
            }
        });
    });

    // Confirm password: validate live on input of either field, never on blur
    function revalidateConfirm() {
        runValidation(confirmEntry);
    }

    confirmPassword.addEventListener('input', revalidateConfirm);
    password.addEventListener('input', revalidateConfirm);

    // On submit: validate everything, block submission if anything fails
    form.addEventListener('submit', function (e) {
        // Also validate required on confirm password at submit time
        const allValid = validations.map(function (v) {
            // For confirm password, treat empty as a required error on submit
            if (v.field === confirmPassword && !confirmPassword.value) {
                showError(v.field, v.span, MSG.passwordMismatch || 'Полетата за парола трябва да съответстват!', v.hint);
                return false;
            }
            return runValidation(v);
        }).every(Boolean);

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
