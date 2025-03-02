namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Cart;
    using BeachEquipmentStore.ViewModels.Product;

    public interface IProductService
    {
        Task<bool> IsInStock(Guid productId, int quantity);

        Task<List<ProductViewModel>> GetAllProductsAsync();

        Task<ExtendedProductViewModel> GetProductById(Guid productId);

        Task<List<ProductViewModel>> GetRandomProductsInStockAsync();

        Task<List<ProductViewModel>> GetProductsInCart(List<CartViewModel> cartItems);

        Task<ExtendedFiltrationViewModel> GetFilteredProductsAsync(string keyword, int categoryId, int manufacturerId);

        Task RestockProduct(Guid productId, int quantity);
    }
}
