document.addEventListener('DOMContentLoaded', function () {
    const productsView = document.getElementById('filter-form');
    if (!productsView) return;

    const categoryDropdown = document.getElementById('category-dropdown');
    const manufacturerDropdown = document.getElementById('manufacturer-dropdown');
    const keywordInput = document.getElementById('keyword');
    const clearFiltersButton = document.getElementById('clear-filters-button');
    const basePath = window.location.pathname;

    function buildParams() {
        const params = new URLSearchParams();
        const keyword = keywordInput.value.trim();
        const categoryId = categoryDropdown.value;
        const manufacturerId = manufacturerDropdown.value;

        if (keyword) params.set('keyword', keyword);
        if (categoryId && categoryId !== 'All') params.set('categoryId', categoryId);
        if (manufacturerId && manufacturerId !== 'All') params.set('manufacturerId', manufacturerId);

        return params;
    }

    function navigate() {
        const qs = buildParams().toString();
        window.location.href = qs ? `${basePath}?${qs}` : basePath;
    }

    // Sanitize on load
    const currentParams = new URLSearchParams(window.location.search);
    ['categoryId', 'manufacturerId'].forEach(key => {
        if (currentParams.has(key) && !/^\d+$/.test(currentParams.get(key))) {
            currentParams.delete(key);
        }
    });
    const sanitizedQs = currentParams.toString();
    window.history.replaceState(null, '', sanitizedQs ? `${basePath}?${sanitizedQs}` : basePath);

    productsView.addEventListener('submit', function (e) {
        e.preventDefault();
        navigate();
    });

    clearFiltersButton.addEventListener('click', function () {
        window.location.href = basePath;
    });
});