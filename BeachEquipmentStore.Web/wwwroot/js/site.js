document.addEventListener("DOMContentLoaded", function () {
    const categoryDropdown = document.getElementById("category-dropdown");
    const manufacturerDropdown = document.getElementById("manufacturer-dropdown");

    categoryDropdown.addEventListener("change", updateUrl);
    manufacturerDropdown.addEventListener("change", updateUrl);

    function updateUrl() {
        const keyword = document.querySelector("input[name='keyword']").value;
        const categoryId = categoryDropdown.value;
        const manufacturerId = manufacturerDropdown.value;

        const urlParams = new URLSearchParams();
        if (keyword) urlParams.set("keyword", keyword);
        if (categoryId !== "All") urlParams.set("categoryId", categoryId);
        if (manufacturerId !== "All") urlParams.set("manufacturerId", manufacturerId);

        const queryString = urlParams.toString();
        const newUrl = `${window.location.origin}${window.location.pathname}?${queryString}`;
        window.history.replaceState(null, "", newUrl);
    }

    const clearFiltersButton = document.getElementById('clear-filters-button');
    const keywordInput = document.getElementById('keyword');

    clearFiltersButton.addEventListener('click', function () {
        categoryDropdown.value = 'All';
        manufacturerDropdown.value = 'All';
        keywordInput.value = '';
        document.getElementById('filter-form').submit();
    });

    document.getElementById('clear-filters-button').addEventListener('click', function () {
        console.log('Clear Filters button clicked');
        document.getElementById('filter-form').submit();
    });
});
