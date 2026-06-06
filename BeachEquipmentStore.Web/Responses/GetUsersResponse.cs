namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.User;

    public class GetUsersResponse : BaseResponse
    {
        public List<UserViewModel> Users { get; set; } = new();
    }
}
