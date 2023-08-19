using BeachEquipmentStore.Web.ViewModels.User;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllNotAdminUsers();

        Task MakeAdmin(Guid userId);
    }
}
