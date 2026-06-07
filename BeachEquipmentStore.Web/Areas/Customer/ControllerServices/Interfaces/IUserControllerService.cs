using BeachEquipmentStore.ViewModels.Profile;
using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces
{
    public interface IUserControllerService
    {
        Task<GetUserDetailsResponse> GetUserDetailsAsync();
        Task<BaseResponse> ChangeUserDetailsAsync(UserDetailsViewModel userDetails);
        Task<ChangePasswordResponse> ChangeUserPasswordAsync(ChangePasswordViewModel model);
        Task<GetAllAddressesResponse> GetAllUserAddressesAsync();
        Task<BaseResponse> AddUserAddressAsync(string name, string town, string zipCode, bool isPrimaryAddress);
        Task<GetAddressResponse> GetUserAddressDetailsAsync(Guid addressId);
        Task<BaseResponse> ChangeUserAddressDetailsAsync(Guid addressId, string name, string town, string zipCode);
        Task<DeleteAddressResponse> DeleteUserAddressAsync(Guid addressId);
        Task<GetOrderHistoryResponse> GetUserOrderHistoryAsync();
    }
}
