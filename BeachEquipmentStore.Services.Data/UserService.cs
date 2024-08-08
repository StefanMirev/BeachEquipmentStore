using BeachEquipmentStore.Data;
using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using static BeachEquipmentStore.Common.GeneralApplicationConstants;

namespace BeachEquipmentStore.Services.Data
{
    public class UserService : IUserService
    {
        private readonly EquipmentStoreDbContext _data;
        private readonly UserManager<ApplicationUser> _users;

        public UserService(EquipmentStoreDbContext data, UserManager<ApplicationUser> users)
        {
            _data = data;
            _users = users;
        }

        public async Task<List<UserViewModel>> GetAllNotAdminUsers()
        {
            var allUsers = await _data.Users.ToListAsync();
            var adminUsers = await _users.GetUsersInRoleAsync(AdminRoleName);

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

            await _users.AddToRoleAsync(user, AdminRoleName);
            await _data.SaveChangesAsync();
        }
    }
}
