using BeachEquipmentStore.Services.Data.Models.Profile;
using BeachEquipmentStore.Web.ViewModels.Profile;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface IProfileService
    {
        Task<UserDetailsServiceModel> GetUserDetails(Guid userId);

        Task ChangeUserDetails(Guid userId, UserDetailsViewModel DetailsModel);

        Task<List<AddressDetailsViewModel>> GetAllAddresses(Guid userId);

        Task<AddressDetailsViewModel> GetAddressDetails(string addressId);

        Task AddAddress(Guid userId, string name, string town, string zipCode, bool? isPrimaryAddress);

        Task ChangeAddressDetails(Guid addressId, string address, string town, int zipCode);

        Task<List<AddressDetailsViewModel>> DeleteAddress(Guid userId, Guid addressId);

        Task<List<OrderHistoryServiceModel>> GetOrderHistory(Guid userId);
    }
}
