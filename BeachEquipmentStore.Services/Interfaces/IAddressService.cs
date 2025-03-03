namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Profile;

    public interface IAddressService
    {
        Task<List<AddressDetailsViewModel>> GetAllAddresses(Guid userId);

        Task<AddressDetailsViewModel> GetAddressDetails(string addressId);

        Task AddAddress(Guid userId, string name, string town, string zipCode, bool? isPrimaryAddress);

        Task ChangeAddressDetails(Guid addressId, string address, string town, string zipCode);

        Task<List<AddressDetailsViewModel>> DeleteAddress(Guid userId, Guid addressId);
    }
}
