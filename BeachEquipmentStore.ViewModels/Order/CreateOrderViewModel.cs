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

        public UserDetailsViewModel UserDetails { get; set; } = null!;

        public AddressDetailsViewModel? UserAddress { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
