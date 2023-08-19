using BeachEquipmentStore.Web.ViewModels.Product;

namespace BeachEquipmentStore.Web.Areas.Admin.ViewModels.Product
{
    public class RestockProductsViewModel
    {
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
