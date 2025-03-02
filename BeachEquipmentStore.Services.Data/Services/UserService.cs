namespace BeachEquipmentStore.Services.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.ViewModels.User;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using static BeachEquipmentStore.Common.GeneralApplicationConstants;

    public class UserService : IUserService
    {
        private readonly EquipmentStoreDbContext _data;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(EquipmentStoreDbContext data, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _data = data;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<UserViewModel?> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            var appUser = await _userManager.GetUserAsync(user);

            return appUser == null ? null : new UserViewModel
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName
            };
        }

        public bool IsUserSignedIn(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }

        public async Task<UserDetailsViewModel> GetUserDetails(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentNullException("Потребителят не съществува!");
            }

            ApplicationUser currentUser = await _data.Users.FirstAsync(u => u.Id == userId);

            return new UserDetailsViewModel()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber
            };
        }

        public async Task ChangeUserDetails(Guid userId, UserDetailsViewModel DetailsModel)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentNullException("Потребителят не съществува!");
            }

            var currentUser = await _data.Users.FirstAsync(u => u.Id == userId);

            currentUser.FirstName = DetailsModel.FirstName;
            currentUser.LastName = DetailsModel.LastName;
            currentUser.Email = DetailsModel.Email;
            currentUser.PhoneNumber = DetailsModel.PhoneNumber;

            await _data.SaveChangesAsync();
        }

        public async Task<IdentityResult> ChangeUserPasswordAsync(UserViewModel user, string currentPassword, string newPassword)
        {
            var applicationUser = await _userManager.FindByIdAsync(user.Id.ToString());

            return await _userManager.ChangePasswordAsync(applicationUser, currentPassword, newPassword);
        }

        public async Task<List<UserViewModel>> GetAllNotAdminUsers()
        {
            var allUsers = await _data.Users.ToListAsync();
            var adminUsers = await _userManager.GetUsersInRoleAsync(AdminRoleName);

            foreach (var adminUser in adminUsers)
            {
                allUsers.Remove(adminUser);
            }

            return allUsers.Select(u => new UserViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            })
                .ToList();

        }

        public async Task MakeAdmin(Guid userId)
        {
            var user = _data.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Не е намерен такъв потребител!");
            }

            await _userManager.AddToRoleAsync(user!, AdminRoleName);
            await _data.SaveChangesAsync();
        }
    }
}
