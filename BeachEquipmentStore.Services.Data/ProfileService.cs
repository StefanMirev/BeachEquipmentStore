using BeachEquipmentStore.Data;
using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeachEquipmentStore.Services.Data
{
    public class ProfileService : IProfileService
    {
        private readonly EquipmentStoreDbContext _data;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService(EquipmentStoreDbContext data, UserManager<ApplicationUser> userManager)
        {
            _data = data;
            _userManager = userManager;
        }

        public async Task<UserInfoServiceModel> GetUserInfo(string userId)
        {
            ApplicationUser currentUser = await _data.Users.FirstAsync(u => u.Id.ToString() == userId);

            return new UserInfoServiceModel()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber
            };
        }

        public async Task ChangePassword(string userId, string currentPassword, string newPassword, string newPasswordConfirmation)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var currentUser = await _data.Users.FirstAsync(u => u.Id.ToString() == userId);

            if (await _userManager.CheckPasswordAsync(currentUser, currentPassword))
            {
                if(newPassword == newPasswordConfirmation)
                {
                    currentUser.PasswordHash = hasher.HashPassword(currentUser, newPassword);
                    await _data.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Паролите в полетата \"Нова парола\" и \"Потвърди парола\" се различават!");
                }
            }
            else
            {
                throw new ArgumentException("Въведената парола е грешна! Моля опитайте отново!");
            }
        }
        
        public async Task ChangeUserInfo(string userId, string firstName, string lastName, string email, string phoneNumber)
        {
            var currentUser = await _data.Users.FirstAsync(u => u.Id.ToString() == userId);

            currentUser.FirstName = firstName;
            currentUser.LastName = lastName;
            currentUser.Email = email;
            currentUser.PhoneNumber = phoneNumber;

            await _data.SaveChangesAsync();
        }
       
        public async Task<List<AddressServiceModel>> GetAllAddressesInfo(string userId)
        {
            return await _data.Addresses
                .Where(a => a.CustomerId.ToString() == userId)
                .Select(a => new AddressServiceModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Town = a.Town,
                    ZipCode = a.ZipCode
                })
                .ToListAsync();
        }

        public async Task<AddressServiceModel> GetAddressInfo(string addressId)
        {
            var address = await _data.Addresses.FirstAsync(a => a.Id.ToString() == addressId);

            return new AddressServiceModel
            {
                Id = address.Id,
                Name = address.Name,
                Town = address.Town,
                ZipCode = address.ZipCode
            };
        }

        public async Task AddAddress(string userId, string name, string town, int zipCode)
        {
            Address address = new Address()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Town = town,
                ZipCode = zipCode,
                CustomerId = Guid.Parse(userId)
            };

            _data.Addresses.Add(address);
            await _data.SaveChangesAsync();
        }

        public async Task ChangeAddressInfo(Guid addressId, string name, string town, int zipCode)
        {
            var addressToChange = await _data.Addresses.FirstAsync(a => a.Id == addressId);

            addressToChange.Name = name;
            addressToChange.Town = town;
            addressToChange.ZipCode = zipCode;

            await _data.SaveChangesAsync();


        }

        public async Task DeleteAddress(Guid addressId)
        {
            Address address = await _data.Addresses.FirstAsync(a => a.Id == addressId);
            _data.Addresses.Remove(address);
            await _data.SaveChangesAsync();
        }

        public async Task<List<OrderHistoryServiceModel>> GetOrderHistory(string userId)
        {
            return await _data.Orders
                .Where(o => o.CustomerId.ToString() == userId)
                .Select(o => new OrderHistoryServiceModel
                {
                    Id = o.Id,
                    DeliveryStatus = o.DeliveryStatus.ToString(),
                    OrderDate = o.OrderDate,
                    TotalPrice = o.TotalPrice
                })
                .ToListAsync();
        }
    }
}
