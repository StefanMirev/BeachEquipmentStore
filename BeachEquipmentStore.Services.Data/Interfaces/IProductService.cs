namespace BeachEquipmentStore.Services.Data.Interfaces
{
    using BeachEquipmentStore.Services.Data.Models.Cart;
    using BeachEquipmentStore.Services.Data.Models.Product;

    public interface IProductService
    {
        Task<bool> IsInStock(Guid productId, int quantity);

        Task<List<ProductServiceModel>> GetAllProductsAsync();
        
        Task<ExtendedProductServiceModel> GetProductById(Guid productId);

        Task<List<ProductServiceModel>> GetRandomProductsInStockAsync();

        Task<List<ProductServiceModel>> GetProductsByCategoryAsync(int categoryId);

        Task<List<ProductServiceModel>> GetProductsByManufacturerAsync(int manufacturerId);

        Task<List<ProductServiceModel>> GetProductsInCart(List<CartServiceModel> cartItems);

        Task<ExtendedFiltrationServiceModel> GetFilteredProductsAsync(string keyword, int categoryId, int manufacturerId);
    }
}
