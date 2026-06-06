namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Product;

    public class GetProductResponse : BaseResponse
    {
        public ExtendedProductViewModel Product { get; set; } = null!;
    }
}
