using BeachEquipmentStore.Data;
using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Profile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data
{
    public class ProfileService : IProfileService
    {
        private readonly EquipmentStoreDbContext _data;

        public ProfileService(EquipmentStoreDbContext data)
        {
            _data = data;
        }

        public Task<AddressServiceModel> ChangeAddressInfo(string address, string town, string zipCode)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordServiceModel> ChangePassword(string currentPassword, string newPasswordHash, string newPasswordConfirmation)
        {
            throw new NotImplementedException();
        }

        public Task<MyProfileServiceModel> ChangeUserInfo(string firstName, string lastName, string email, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<AddressServiceModel> GetAddressInfo(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderHistoryServiceModel> GetOrderHistory(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<MyProfileServiceModel> GetUserInfo(string userId)
        {
            ApplicationUser currentUser = await _data.Users.FirstAsync(u => u.Id.ToString() == userId);

            return new MyProfileServiceModel()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber
            };
        }
    }
}
