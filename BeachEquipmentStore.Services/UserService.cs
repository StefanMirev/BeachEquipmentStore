namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Common.Helpers;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.ViewModels.User;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class UserService : IUserService
    {
        private readonly AllBusinessLogics _allBls;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(AllBusinessLogics allBls, IHttpContextAccessor httpContextAccessor)
        {
            _allBls = allBls;
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentLoggedInUserId()
        {
            var claim = _httpContextAccessor.HttpContext?.User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            return Guid.TryParse(claim, out var id) ? id : Guid.Empty;
        }

        public Task<UserViewModel?> GetCurrentLoggedInUserAsync()
        {
            var principal = _httpContextAccessor.HttpContext?.User;

            if (principal?.Identity?.IsAuthenticated != true)
                return Task.FromResult<UserViewModel?>(null);

            var idClaim = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(idClaim, out var id))
                return Task.FromResult<UserViewModel?>(null);

            var model = new UserViewModel
            {
                Id = id,
                Email = principal.FindFirstValue(ClaimTypes.Email) ?? string.Empty,
                UserName = principal.FindFirstValue(ClaimTypes.Email) ?? string.Empty,
                FirstName = principal.FindFirstValue(ClaimTypes.GivenName) ?? string.Empty,
                LastName = principal.FindFirstValue(ClaimTypes.Surname) ?? string.Empty
            };

            return Task.FromResult<UserViewModel?>(model);
        }

        public bool IsUserSignedIn(ClaimsPrincipal user)
            => user.Identity?.IsAuthenticated == true;

        public bool IsCurrentLoggedInUserAdmin()
        {
            var userType = _httpContextAccessor.HttpContext?.User
                .FindFirstValue("UserType");

            return userType == "Admin";
        }

        public async Task<UserDetailsViewModel> GetUserDetailsAsync(Guid userId)
        {
            var customerUser = await _allBls.CustomerUsersBL.FindAsNoTrackingAsync(userId)
                ?? throw new ArgumentException(UserNotFound);

            var user = await _allBls.UsersBL.FindAsNoTrackingAsync(userId)
                ?? throw new ArgumentException(UserNotFound);

            return new UserDetailsViewModel
            {
                FirstName = customerUser.FirstName,
                LastName = customerUser.LastName,
                Email = user.Email,
                PhoneNumber = customerUser.PhoneNumber ?? string.Empty
            };
        }

        public async Task ChangeUserDetailsAsync(UserDetailsViewModel detailsModel)
        {
            using var transaction = _allBls.CustomerUsersBL.GetTransactionProxy();
            try
            {
                var userId = GetCurrentLoggedInUserId();

                var customerUser = await _allBls.CustomerUsersBL.FindAsync(userId)
                    ?? throw new ArgumentException(UserNotFound);

                var user = await _allBls.UsersBL.FindAsync(userId)
                    ?? throw new ArgumentException(UserNotFound);

                customerUser.FirstName = detailsModel.FirstName;
                customerUser.LastName = detailsModel.LastName;
                customerUser.PhoneNumber = detailsModel.PhoneNumber;

                user.Email = detailsModel.Email;
                user.Username = detailsModel.Email;

                await _allBls.CustomerUsersBL.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> ChangeUserPasswordAsync(string currentPassword, string newPassword)
        {
            var userId = GetCurrentLoggedInUserId();

            var user = await _allBls.UsersBL.FindAsync(userId)
                ?? throw new ArgumentException(UserNotFound);

            if (!PasswordHasher.VerifyPassword(currentPassword, user.PasswordHash))
                return false;

            user.PasswordHash = PasswordHasher.HashPassword(newPassword);
            user.SecurityStamp = Guid.NewGuid().ToString();

            await _allBls.UsersBL.SaveChangesAsync();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return true;
        }

        public async Task<List<UserViewModel>> GetAllNonAdminUsersAsync()
        {
            var users = await _allBls.CustomerUsersBL
                .AsQueryable()
                .Join(
                    _allBls.UsersBL.AsQueryable(),
                    cu => cu.Id,
                    u => u.Id,
                    (cu, u) => new UserViewModel
                    {
                        Id = cu.Id,
                        FirstName = cu.FirstName,
                        LastName = cu.LastName,
                        Email = u.Email,
                        UserName = u.Email,
                        CreatedAt = u.CreatedAt
                    })
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();

            return users;
        }

        public Task<bool> MakeAdminAsync(Guid userId)
        {
            // Replaced by IAuthService.CreateAdminUserAsync — stub kept until web layer is updated.
            throw new NotImplementedException("Use IAuthService.CreateAdminUserAsync instead.");
        }
    }
}
