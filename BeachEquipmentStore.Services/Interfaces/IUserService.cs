namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.ViewModels.User;
    using Microsoft.AspNetCore.Identity;
    using System.Security.Claims;

    public interface IUserService
    {
        Task<UserViewModel?> GetCurrentUserAsync(ClaimsPrincipal user);

        bool IsUserSignedIn(ClaimsPrincipal user);

        Task<UserDetailsViewModel> GetUserDetails(Guid userId);

        Task ChangeUserDetails(Guid userId, UserDetailsViewModel DetailsModel);

        Task<IdentityResult> ChangeUserPasswordAsync(UserViewModel user, string currentPassword, string newPassword);

        Task<List<UserViewModel>> GetAllNotAdminUsers();

        Task MakeAdmin(Guid userId);
    }
}
