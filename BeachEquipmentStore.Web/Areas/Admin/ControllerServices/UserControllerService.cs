using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Areas.Admin.Interfaces;
using BeachEquipmentStore.Web.Responses;
using static BeachEquipmentStore.Common.Constants.Messages;

namespace BeachEquipmentStore.Web.Areas.Admin.ControllerServices
{
    public class UserControllerService : IUserControllerService
    {
        private readonly IUserService _userService;

        public UserControllerService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUsersResponse> GetAllNonAdminUsersAsync()
        {
            try
            {
                return new GetUsersResponse
                {
                    IsSuccess = true,
                    Users = await _userService.GetAllNonAdminUsersAsync()
                };
            }
            catch (Exception ex)
            {
                return new GetUsersResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<BaseResponse> MakeAdminAsync(Guid userId)
        {
            try
            {
                var isSuccess = await _userService.MakeAdminAsync(userId);

                return new BaseResponse
                {
                    IsSuccess = isSuccess,
                    ResponseMessage = isSuccess ? UserAdminGrantSuccess : UserAdminGrantFailure
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
    }
}
