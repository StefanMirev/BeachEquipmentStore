using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.ViewModels.Profile;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
using static BeachEquipmentStore.Common.Constants.Messages;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices
{
    public class UserControllerService : IUserControllerService
    {
        private readonly IAddressService _addressService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public UserControllerService(IAddressService addressService, IOrderService orderService, IUserService userService)
        {
            _addressService = addressService;
            _orderService = orderService;
            _userService = userService;
        }

        public async Task<GetUserDetailsResponse> GetUserDetailsAsync()
        {
            try
            {
                var userDetails = await _userService.GetUserDetailsAsync(_userService.GetCurrentLoggedInUserId());

                return new GetUserDetailsResponse
                {
                    IsSuccess = true,
                    UserDetails = userDetails
                };
            }
            catch (Exception ex)
            {
                return new GetUserDetailsResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<BaseResponse> ChangeUserDetailsAsync(UserDetailsViewModel userDetails)
        {
            try
            {
                await _userService.ChangeUserDetailsAsync(userDetails);

                return new BaseResponse
                {
                    IsSuccess = true,
                    ResponseMessage = UserDetailsUpdateSuccess
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<ChangePasswordResponse> ChangeUserPasswordAsync(ChangePasswordViewModel model)
        {
            try
            {
                if (_userService.GetCurrentLoggedInUserId() == Guid.Empty)
                {
                    throw new InvalidOperationException(UserNotFound);
                }

                var changePasswordResult = await _userService.ChangeUserPasswordAsync(model.CurrentPassword, model.NewPassword);

                if (!changePasswordResult.Succeeded)
                {
                    throw new ArgumentException(string.Join("\n", changePasswordResult.Errors
                        .Select(e => e.Description == "Incorrect password."
                            ? UserIncorrectPassword
                            : e.Description)));
                }

                return new ChangePasswordResponse
                {
                    UserFound = true,
                    IsSuccess = true,
                    ResponseMessage = UserPasswordChangeSuccess
                };
            }
            catch (InvalidOperationException ex)
            {
                return new ChangePasswordResponse
                {
                    UserFound = false,
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ChangePasswordResponse
                {
                    UserFound = true,
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<GetAllAddressesResponse> GetAllUserAddressesAsync()
        {
            try
            {
                var addresses = await _addressService.GetAllAddressesByUserIdAsync(_userService.GetCurrentLoggedInUserId());

                return new GetAllAddressesResponse
                {
                    IsSuccess = true,
                    Addresses = addresses
                };
            }
            catch (Exception ex)
            {
                return new GetAllAddressesResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<BaseResponse> AddUserAddressAsync(string name, string town, string zipCode, bool isPrimaryAddress)
        {
            try
            {
                await _addressService.AddAddressAsync(_userService.GetCurrentLoggedInUserId(), name, town, zipCode, isPrimaryAddress);

                return new BaseResponse
                {
                    IsSuccess = true,
                    ResponseMessage = AddressAddSuccess
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<GetAddressResponse> GetUserAddressDetailsAsync(Guid addressId)
        {
            try
            {
                var address = await _addressService.GetAddressDetailsByIdAsync(addressId);

                return new GetAddressResponse
                {
                    IsSuccess = true,
                    Address = address
                };
            }
            catch (Exception ex)
            {
                return new GetAddressResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<BaseResponse> ChangeUserAddressDetailsAsync(Guid addressId, string name, string town, string zipCode)
        {
            try
            {
                await _addressService.UpdateAddressByIdAsync(addressId, name, town, zipCode);

                return new BaseResponse
                {
                    IsSuccess = true,
                    ResponseMessage = AddressUpdateSuccess
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<DeleteAddressResponse> DeleteUserAddressAsync(Guid addressId)
        {
            try
            {
                var addresses = await _addressService.DeleteAddressByIdAsync(_userService.GetCurrentLoggedInUserId(), addressId);

                return new DeleteAddressResponse
                {
                    IsSuccess = true,
                    RemainingCount = addresses.Count
                };
            }
            catch (Exception ex)
            {
                return new DeleteAddressResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<GetOrderHistoryResponse> GetUserOrderHistoryAsync()
        {
            try
            {
                return new GetOrderHistoryResponse
                {
                    IsSuccess = true,
                    Orders = await _orderService.GetCurrentUserOrderHistoryAsync()
                };
            }
            catch (Exception ex)
            {
                return new GetOrderHistoryResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

    }
}
