namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Profile;

    public class GetAddressResponse : BaseResponse
    {
        public AddressDetailsViewModel Address { get; set; } = null!;
    }
}
