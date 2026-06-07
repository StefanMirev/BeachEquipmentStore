const preloader = document.querySelector('#preloader');
if (preloader) {
    window.addEventListener('load', () => {
        preloader.remove();
    });
}

document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.toast').forEach(function (el) {
        bootstrap.Toast.getOrCreateInstance(el).show();
    });

    // Suppress browser-native validation popups across the whole app
    document.querySelectorAll('form').forEach(function (form) {
        form.setAttribute('novalidate', '');
    });

    // Hold-to-reveal password toggle
    // Usage: <button type="button" data-password-toggle="inputId">
    document.querySelectorAll('[data-password-toggle]').forEach(function (btn) {
        const input = document.getElementById(btn.dataset.passwordToggle);
        if (!input) return;

        function reveal() { input.type = 'text'; }
        function hide()   { input.type = 'password'; }

        btn.addEventListener('mousedown',  reveal);
        btn.addEventListener('touchstart', reveal, { passive: true });
        btn.addEventListener('mouseup',    hide);
        btn.addEventListener('mouseleave', hide);
        btn.addEventListener('touchend',   hide);
        btn.addEventListener('touchcancel', hide);

        // Prevent the button click from triggering form submission or stealing focus
        btn.addEventListener('click', function (e) { e.preventDefault(); });
    });
});
