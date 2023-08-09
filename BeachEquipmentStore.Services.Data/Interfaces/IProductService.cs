namespace BeachEquipmentStore.Services.Data.Interfaces
{
    using BeachEquipmentStore.Web.ViewModels.Home;

    public interface IProductService
    { 
        Task<List<IndexViewModel>> GetNineRandomProductsInStockAsync();
    }
}
