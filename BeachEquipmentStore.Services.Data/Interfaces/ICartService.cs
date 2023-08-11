namespace BeachEquipmentStore.Services.Data.Interfaces
{
    using BeachEquipmentStore.Services.Data.Models.Cart;

    public interface ICartService
    {
        Task AddItemToCart(Guid customerId, Guid productId, int quantity);

        Task<List<CartServiceModel>> GetItemsInCart(Guid customerId);
    }
}
