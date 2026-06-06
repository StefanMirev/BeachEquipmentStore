namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Profile;

    public class GetAllAddressesResponse : BaseResponse
    {
        public List<AddressDetailsViewModel> Addresses { get; set; } = new();
    }
}
