namespace BeachEquipmentStore.ViewModels.Order
{
    using BeachEquipmentStore.ViewModels.Cart;
    using BeachEquipmentStore.ViewModels.Profile;

    public class CreateOrderViewModel
    {
        public UserDetailsViewModel UserDetails { get; set; } = null!;

        public AddressDetailsViewModel? UserAddress { get; set; }

        public List<CartProductViewModel> Products { get; set; } = new();
    }
}
