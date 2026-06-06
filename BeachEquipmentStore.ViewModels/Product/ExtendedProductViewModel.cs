namespace BeachEquipmentStore.ViewModels.Product
{
    public class ExtendedProductViewModel : ProductViewModel
    {
        public string Description { get; set; } = null!;

        public int Barcode { get; set; }

        public int Stock { get; set; }
    }
}
