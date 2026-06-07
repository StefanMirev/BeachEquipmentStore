namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.ViewModels.User;
    using System.Security.Claims;

    public interface IUserService
    {
        Guid GetCurrentLoggedInUserId();

        Task<UserViewModel?> GetCurrentLoggedInUserAsync();

        bool IsUserSignedIn(ClaimsPrincipal user);

        bool IsCurrentLoggedInUserAdmin();

        Task<UserDetailsViewModel> GetUserDetailsAsync(Guid userId);

        Task ChangeUserDetailsAsync(UserDetailsViewModel detailsModel);

        Task<bool> ChangeUserPasswordAsync(string currentPassword, string newPassword);

        Task<List<UserViewModel>> GetAllNonAdminUsersAsync();

        Task<bool> MakeAdminAsync(Guid userId);
    }
}
