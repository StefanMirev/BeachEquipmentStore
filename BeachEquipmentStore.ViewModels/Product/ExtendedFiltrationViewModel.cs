namespace BeachEquipmentStore.ViewModels.Product
{
    public class ExtendedFiltrationViewModel
    {
        public string Keyword { get; set; } = null!;

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public FilterProductsViewModel FilteredProducts { get; set; } = null!;
    }
}
