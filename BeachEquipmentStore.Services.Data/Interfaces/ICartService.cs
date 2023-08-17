namespace BeachEquipmentStore.Services.Data.Interfaces
{
    using BeachEquipmentStore.Services.Data.Models.Cart;

    public interface ICartService
    {
        Task AddItemToCart(Guid userId, Guid productId, int quantity);

        Task<List<CartServiceModel>> GetItemsInCart(Guid userId);

        Task RemoveAllItemsFromCart(Guid userId);

        Task RemoveItemFromCart(Guid userId, Guid productId);
    }
}
