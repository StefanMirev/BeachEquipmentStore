namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Profile;

    public class GetUserDetailsResponse : BaseResponse
    {
        public UserDetailsViewModel UserDetails { get; set; } = null!;
    }
}
