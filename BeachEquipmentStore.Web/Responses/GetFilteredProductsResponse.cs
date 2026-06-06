namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Product;

    public class GetFilteredProductsResponse : BaseResponse
    {
        public ProductSearchViewModel Products { get; set; } = null!;
    }
}
