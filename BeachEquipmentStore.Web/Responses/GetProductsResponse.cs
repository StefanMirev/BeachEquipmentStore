namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Product;

    public class GetProductsResponse : BaseResponse
    {
        public List<ProductViewModel> Products { get; set; } = new();
    }
}
