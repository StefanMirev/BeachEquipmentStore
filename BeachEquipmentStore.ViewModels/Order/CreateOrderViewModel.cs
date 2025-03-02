namespace BeachEquipmentStore.ViewModels.Order
{
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.ViewModels.Profile;

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
