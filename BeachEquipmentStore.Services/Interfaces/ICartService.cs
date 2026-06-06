namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.Services.DTOs;

    public interface ICartService
    {
        Task AddItemToCartAsync(Guid productId, int quantity);

        Task<List<CartItemDto>> GetItemsInCartAsync();

        Task RemoveAllItemsFromCartAsync();

        Task RemoveItemFromCartAsync(Guid productId);

        Task ClearCartAfterOrderAsync();
    }
}
