document.addEventListener('DOMContentLoaded', function () {
    const backBtn = document.getElementById('goBackBtn');
    if (backBtn) {
        backBtn.addEventListener('click', function () {
            if (window.history.length > 1) {
                window.history.back();
            } else {
                window.location.href = '/';
            }
        });
    }
});