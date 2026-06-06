namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Cart;

    public class GetCartResponse : BaseResponse
    {
        public List<CartProductViewModel> Products { get; set; } = new();
    }
}
