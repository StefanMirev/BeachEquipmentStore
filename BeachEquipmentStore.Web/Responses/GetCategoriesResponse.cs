namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Category;

    public class GetCategoriesResponse : BaseResponse
    {
        public List<CategoryViewModel> Categories { get; set; } = new();
    }
}
