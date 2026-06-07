namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.ViewModels.User;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Security.Claims;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class UserService : IUserService
    {
        private readonly AllBusinessLogics _allBls;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(AllBusinessLogics allBls, IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _allBls = allBls;
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
            var currentUser = await _allBls.UsersBL.FindAsNoTrackingAsync(userId)
                ?? throw new ArgumentNullException(UserNotFound);

            return new UserDetailsViewModel
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email!,
                PhoneNumber = currentUser.PhoneNumber!
            };
        }

        public async Task ChangeUserDetailsAsync(UserDetailsViewModel detailsModel)
        {
            using var transaction = _allBls.UsersBL.GetTransactionProxy();
            try
            {
                var currentUser = await _allBls.UsersBL.FindAsync(GetCurrentLoggedInUserId())
                    ?? throw new ArgumentNullException(UserNotFound);

                currentUser.FirstName = detailsModel.FirstName;
                currentUser.LastName = detailsModel.LastName;
                currentUser.Email = detailsModel.Email;
                currentUser.PhoneNumber = detailsModel.PhoneNumber;
                currentUser.UpdatedAt = DateTime.Now;

                await _allBls.UsersBL.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IdentityResult> ChangeUserPasswordAsync(string currentPassword, string newPassword)
        {
            var applicationUser = await _userManager.FindByIdAsync(GetCurrentLoggedInUserId().ToString())
                ?? throw new ArgumentNullException(UserNotFound);

            return await _userManager.ChangePasswordAsync(applicationUser, currentPassword, newPassword);
        }

        public async Task<List<UserViewModel>> GetAllNonAdminUsersAsync()
        {
            var admins = await _userManager.GetUsersInRoleAsync(AdminRoleName);
            var adminIds = admins.Select(a => a.Id).ToHashSet();

            var users = await _allBls.UsersBL.GetAllAsync(u => !adminIds.Contains(u.Id));

            return users
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email ?? string.Empty,
                    CreatedAt = u.CreatedAt
                })
                .OrderByDescending(u => u.CreatedAt)
                .ToList();
        }

        public async Task<bool> MakeAdminAsync(Guid userId)
        {
            using var transaction = _allBls.UsersBL.GetTransactionProxy();
            try
            {
                var user = await _allBls.UsersBL.FindAsync(userId)
                    ?? throw new ArgumentException(UserNotFound);

                var result = await _userManager.AddToRoleAsync(user, AdminRoleName);
                await transaction.CommitAsync();
                return result.Succeeded;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
