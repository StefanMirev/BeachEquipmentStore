namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Cart;

    public interface ICartService
    {
        Task AddItemToCart(Guid userId, Guid productId, int quantity);

        Task<List<CartViewModel>> GetItemsInCart(Guid userId);

        Task RemoveAllItemsFromCart(Guid userId);

        Task RemoveItemFromCart(Guid userId, Guid productId);

        Task ClearCartAfterOrder(Guid userId);
    }
}
