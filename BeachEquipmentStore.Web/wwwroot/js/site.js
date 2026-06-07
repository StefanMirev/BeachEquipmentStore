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
});
