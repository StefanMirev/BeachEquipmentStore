namespace BeachEquipmentStore.Web.Areas.Admin.ViewModels.Product
{
    using BeachEquipmentStore.ViewModels.Product;

    public class RestockProductsViewModel
    {
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
