namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Profile;

    public interface IAddressService
    {
        Task<List<AddressDetailsViewModel>> GetAllAddressesByUserIdAsync(Guid userId);

        Task<AddressDetailsViewModel> GetAddressDetailsByIdAsync(string addressId);

        Task AddAddressAsync(Guid userId, string name, string town, string zipCode, bool isPrimaryAddress = false);

        Task UpdateAddressByIdAsync(Guid addressId, string address, string town, string zipCode);

        Task<List<AddressDetailsViewModel>> DeleteAddressByIdAsync(Guid userId, Guid addressId);
    }
}
