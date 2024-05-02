document.addEventListener('DOMContentLoaded', function () {

    var productsView = document.getElementById('filter-form');
    if (productsView) {
        const urlParams = new URLSearchParams(window.location.search);
        const categoryDropdown = document.getElementById('category-dropdown');
        const manufacturerDropdown = document.getElementById('manufacturer-dropdown');

        categoryDropdown.addEventListener('change', updateUrl);
        manufacturerDropdown.addEventListener('change', updateUrl);

        function isNumeric(value) {
            return /^\d+$/.test(value);
        }

        function checkUrl() {
            const newUrlParams = new URLSearchParams(window.location.search);
            urlParams.forEach((value, key) => {
                if (key === 'categoryId' && !isNumeric(value)) {
                    newUrlParams.set(key, "");
                } else if (key === 'manufacturerId' && !isNumeric(value)) {
                    newUrlParams.set(key, "");
                }
            });

            const queryString = newUrlParams.toString();
            const newUrl = `${window.location.origin}${window.location.pathname}?${queryString}`;
            window.history.replaceState(null, '', newUrl);
        }

        checkUrl();

        function updateUrl() {
            const keyword = document.querySelector('input[name="keyword"]').value;
            const categoryId = categoryDropdown.value;
            const manufacturerId = manufacturerDropdown.value;

            if (keyword) urlParams.set('keyword', keyword);
            if (categoryId !== 'All') urlParams.set('categoryId', categoryId);
            if (manufacturerId !== 'All') urlParams.set('manufacturerId', manufacturerId);

            const queryString = urlParams.toString();
            const newUrl = `${window.location.origin}${window.location.pathname}?${queryString}`;
            window.history.replaceState(null, '', newUrl);
        }

        const clearFiltersButton = document.getElementById('clear-filters-button');
        const keywordInput = document.getElementById('keyword');

        clearFiltersButton.addEventListener('click', function () {
            var keyword = document.getElementById('keyword');
            keyword.value = '';
            var categoryId = document.getElementById('category-dropdown');
            categoryId.value = 'All';
            var manufacturerId = document.getElementById('manufacturer-dropdown');
            manufacturerId.value = 'All';
            productsView.action = 'All';
            productsView.submit();
        });
    }
});

const preloader = document.querySelector('#preloader');
if (preloader) {
    window.addEventListener('load', () => {
        preloader.remove();
    });
}
