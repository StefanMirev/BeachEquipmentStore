namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.Services.DTOs;
    using BeachEquipmentStore.ViewModels.Cart;
    using BeachEquipmentStore.ViewModels.Product;

    public interface IProductService
    {
        Task<bool> IsInStockAsync(Guid productId, int quantity);

        Task<List<ProductViewModel>> GetAllProductsAsync();

        Task<ExtendedProductViewModel> GetProductByIdAsync(Guid productId);

        Task<List<ProductViewModel>> GetRandomProductsInStockAsync();

        Task<List<CartProductViewModel>> GetProductsInCartAsync(List<CartItemDto> cartItems);

        Task<ProductSearchViewModel> GetFilteredProductsAsync(string keyword, int categoryId, int manufacturerId);

        Task RestockProductAsync(Guid productId, int quantity);
    }
}
