namespace BeachEquipmentStore.Services.Data.Interfaces
{
    using BeachEquipmentStore.Services.Data.Models.Cart;
    using BeachEquipmentStore.Services.Data.Models.Product;
    using BeachEquipmentStore.Web.ViewModels.Home;

    public interface IProductService
    { 
        Task<List<ProductServiceModel>> GetAllProductsAsync();
        Task<List<ProductServiceModel>> GetRandomProductsInStockAsync();

        Task<List<ProductServiceModel>> GetProductsByCategoryAsync(int categoryId);

        Task<List<ProductServiceModel>> GetProductsByManufacturerAsync(int manufacturerId);

        Task<List<ProductServiceModel>> GetProductsInCart(List<CartServiceModel> cartItems);
    }
}
