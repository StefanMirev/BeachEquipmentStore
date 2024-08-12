using BeachEquipmentStore.Web.ViewModels.Product;
using BeachEquipmentStore.Web.ViewModels.Profile;

namespace BeachEquipmentStore.Web.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            this.Products = new List<ProductViewModel>();
        }

        public UserInfoViewModel UserInfo { get; set; } = null!;

        public AddressViewModel? UserAddress { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
