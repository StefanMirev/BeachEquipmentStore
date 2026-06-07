using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Admin.Interfaces
{
    public interface IUserControllerService
    {
        Task<GetUsersResponse> GetAllNonAdminUsersAsync();

        Task<BaseResponse> MakeAdminAsync(Guid userId);
    }
}
