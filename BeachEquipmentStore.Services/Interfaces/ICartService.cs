namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Cart;

    public interface ICartService
    {
        Task<List<CartProductViewModel>> GetCartProductsAsync();

        Task AddItemToCartAsync(Guid productId, int quantity);

        Task ClearCartAsync(bool restoreStock);

        Task RemoveItemFromCartAsync(Guid productId);
    }
}
