namespace BeachEquipmentStore.Services.Data.Interfaces
{
    using BeachEquipmentStore.Services.Data.Models;
    using BeachEquipmentStore.Web.ViewModels.Home;

    public interface IProductService
    { 
        Task<List<ProductServiceModel>> GetAllProductsAsync();
        Task<List<ProductServiceModel>> GetRandomProductsInStockAsync();
    }
}
