namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.ViewModels.User;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class UserService : IUserService
    {
        private readonly EquipmentStoreDbContext _data;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(EquipmentStoreDbContext data, IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _data = data;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public Guid GetCurrentLoggedInUserId()
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext!.User);

            return Guid.TryParse(userId, out Guid result) ? result : Guid.Empty;
        }

        public async Task<UserViewModel?> GetCurrentLoggedInUserAsync()
        {
            var userId = GetCurrentLoggedInUserId();

            if (userId != Guid.Empty)
            {

                var appUser = await _userManager.FindByIdAsync(userId.ToString()!);
                return appUser == null ? null : new UserViewModel
                {
                    Id = appUser.Id,
                    UserName = appUser.UserName!,
                    Email = appUser.Email!,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName
                };
            }

            return null;
        }

        public bool IsUserSignedIn(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }

        public bool IsCurrentLoggedInUserAdmin()
        {
            return _httpContextAccessor.HttpContext!.User.IsInRole(AdminRoleName);
        }

        public async Task<UserDetailsViewModel> GetUserDetailsAsync(Guid userId)
        {
            var currentUser = await _data.Users.FirstOrDefaultAsync(u => u.Id == userId) ?? throw new ArgumentNullException(UserNotFound);

            return new UserDetailsViewModel()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email!,
                PhoneNumber = currentUser.PhoneNumber!
            };
        }

        public async Task ChangeUserDetailsAsync(UserDetailsViewModel detailsModel)
        {
            var currentUser = await _data.Users.FirstOrDefaultAsync(u => u.Id == GetCurrentLoggedInUserId()) ?? throw new ArgumentNullException(UserNotFound);

            currentUser.FirstName = detailsModel.FirstName;
            currentUser.LastName = detailsModel.LastName;
            currentUser.Email = detailsModel.Email;
            currentUser.PhoneNumber = detailsModel.PhoneNumber;
            currentUser.UpdatedAt = DateTime.Now;

            await _data.SaveChangesAsync();
        }

        public async Task<IdentityResult> ChangeUserPasswordAsync(string currentPassword, string newPassword)
        {
            var applicationUser = await _userManager.FindByIdAsync(GetCurrentLoggedInUserId().ToString()) ?? throw new ArgumentNullException(UserNotFound);

            return await _userManager.ChangePasswordAsync(applicationUser, currentPassword, newPassword);
        }

        public async Task<List<UserViewModel>> GetAllNonAdminUsersAsync()
        {
            return await _data.Users.Where(u => !_data.UserRoles
                .Any(ur => ur.UserId == u.Id && _data.Roles.Any(r => r.Id == ur.RoleId && r.Name == AdminRoleName)))
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt
                })
               .OrderByDescending(u => u.CreatedAt)
               .ToListAsync();
        }

        public async Task<bool> MakeAdmin(Guid userId)
        {
            var user = await _data.Users.FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new ArgumentException(UserNotFound);

            var result = await _userManager.AddToRoleAsync(user, AdminRoleName);
            return result.Succeeded;
        }
    }
}
