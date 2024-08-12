using BeachEquipmentStore.Data;
using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Profile;
using BeachEquipmentStore.Web.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UserInfoServiceModel> GetUserInfo(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentNullException("Потребителят не съществува!");
            }

            ApplicationUser currentUser = await _data.Users.FirstAsync(u => u.Id == userId);

            return new UserInfoServiceModel()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber
            };
        }

        public async Task ChangeUserInfo(Guid userId, UserInfoViewModel infoModel)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentNullException("Потребителят не съществува!");
            }

            var currentUser = await _data.Users.FirstAsync(u => u.Id == userId);

            currentUser.FirstName = infoModel.FirstName;
            currentUser.LastName = infoModel.LastName;
            currentUser.Email = infoModel.Email;
            currentUser.PhoneNumber = infoModel.PhoneNumber;

            await _data.SaveChangesAsync();
        }

        public async Task<AddressServiceModel> GetAllAddressInfo(Guid userId)
        {
            if (!await _data.Users.AnyAsync(a => a.Id == userId))
            {
                throw new ArgumentException("Потребителят не съществува!");
            }

            if (!await _data.Addresses.AnyAsync(a => a.CustomerId == userId))
            {
                throw new InvalidOperationException("Все още нямате адрес!");
            }

            Address userAddress = await _data.Addresses.FirstAsync(a => a.CustomerId == userId);

            return new AddressServiceModel
            {
                Id = userAddress.Id,
                Name = userAddress.Name,
                Town = userAddress.Town,
                ZipCode = userAddress.ZipCode
            };
        }

        public async Task<AddressServiceModel> GetAddressInfo(string addressId)
        {
            if (!await _data.Addresses.AnyAsync(a => a.Id == Guid.Parse(addressId)))
            {
                throw new InvalidOperationException("Все още нямате адрес!");
            }

            var address = await _data.Addresses.FirstAsync(a => a.Id.ToString() == addressId);

            return new AddressServiceModel
            {
                Id = address.Id,
                Name = address.Name,
                Town = address.Town,
                ZipCode = address.ZipCode
            };
        }

        public async Task AddAddress(Guid userId, string name, string town, string zipCode)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentNullException("Потребителят не съществува!");
            }

            if (!int.TryParse(zipCode, out int result))
            {
                throw new ArgumentException("Моля въведете валиден пощенски код!");
            }

            Address address = new Address()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Town = town,
                ZipCode = int.Parse(zipCode),
                CustomerId = userId
            };

            _data.Addresses.Add(address);
            await _data.SaveChangesAsync();
        }

        public async Task ChangeAddressInfo(Guid addressId, string name, string town, int zipCode)
        {
            if (!await _data.Addresses.AnyAsync(a => a.Id == addressId))
            {
                throw new InvalidOperationException("Все още нямате адрес!!");
            }

            var addressToChange = await _data.Addresses.FirstAsync(a => a.Id == addressId);

            addressToChange.Name = name;
            addressToChange.Town = town;
            addressToChange.ZipCode = zipCode;

            await _data.SaveChangesAsync();
        }

        public async Task DeleteAddress(Guid addressId)
        {
            if (!_data.Addresses.Any(u => u.Id == addressId))
            {
                throw new InvalidOperationException("Адресът не съществува!");
            }

            Address address = await _data.Addresses.FirstAsync(a => a.Id == addressId);
            _data.Addresses.Remove(address);
            await _data.SaveChangesAsync();
        }

        public async Task<List<OrderHistoryServiceModel>> GetOrderHistory(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentNullException("Потребителят не съществува!");
            }

            return await _data.Orders
                .Where(o => o.CustomerId == userId)
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
