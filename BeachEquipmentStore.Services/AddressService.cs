namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Profile;
    using Microsoft.EntityFrameworkCore;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class AddressService : IAddressService
    {
        private readonly EquipmentStoreDbContext _data;

        public AddressService(EquipmentStoreDbContext data)
        {
            _data= data;
        }

        public async Task<List<AddressDetailsViewModel>> GetAllAddressesByUserIdAsync(Guid userId)
        {
            if (!await _data.Users.AnyAsync(a => a.Id == userId))
            {
                throw new ArgumentException(UserNotFound);
            }

            if (!await _data.Addresses.AnyAsync(a => a.CustomerId == userId))
            {
                throw new InvalidOperationException(AddressesEmpty);
            }

            var userAddresses = await _data.Addresses
                .Where(a => a.CustomerId == userId)
                .Select(a => new AddressDetailsViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Town = a.Town,
                    ZipCode = a.ZipCode,
                    IsPrimaryAddress = a.IsPrimaryAddress,
                    CreatedAt = a.CreatedAt
                })
                .OrderByDescending(a => a.IsPrimaryAddress)
                .ThenBy(a => a.CreatedAt)
                .ToListAsync();

            return userAddresses;
        }

        public async Task<AddressDetailsViewModel> GetAddressDetailsByIdAsync(string addressId)
        {
            if (!await _data.Addresses.AnyAsync(a => a.Id == Guid.Parse(addressId)))
            {
                throw new InvalidOperationException(AddressesEmpty);
            }

            var address = await _data.Addresses.FirstAsync(a => a.Id.ToString() == addressId);

            return new AddressDetailsViewModel
            {
                Id = address.Id,
                Name = address.Name,
                Town = address.Town,
                ZipCode = address.ZipCode,
                IsPrimaryAddress = address.IsPrimaryAddress
            };
        }

        public async Task AddAddressAsync(Guid userId, string name, string town, string zipCode, bool isPrimaryAddress = false)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentException(UserNotFound);
            }

            if (_data.Addresses.Where(a => a.CustomerId == userId).Count() >= 10)
            {
                throw new InvalidOperationException(AddressLimitReached);
            }

            if (!int.TryParse(zipCode, out int result))
            {
                throw new ArgumentException(AddressZipCodeInvalid);
            }

            if (isPrimaryAddress)
            {
                var primaryAddress = await _data.Addresses.FirstOrDefaultAsync(a => a.IsPrimaryAddress == true);

                if(primaryAddress != null)
                {
                    primaryAddress.IsPrimaryAddress = false;
                }
            }

            var address = new Address()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Town = town,
                ZipCode = zipCode,
                IsPrimaryAddress = isPrimaryAddress,
                CreatedAt = DateTime.Now,
                CustomerId = userId
            };

            await _data.Addresses.AddAsync(address);
            await _data.SaveChangesAsync();
        }

        public async Task UpdateAddressByIdAsync(Guid addressId, string name, string town, string zipCode)
        {
            if (!await _data.Addresses.AnyAsync(a => a.Id == addressId))
            {
                throw new InvalidOperationException(AddressesEmpty);
            }

            var addressToChange = await _data.Addresses.FirstAsync(a => a.Id == addressId);

            addressToChange.Name = name;
            addressToChange.Town = town;
            addressToChange.ZipCode = zipCode;
            addressToChange.UpdatedAt = DateTime.Now;

            await _data.SaveChangesAsync();
        }

        public async Task<List<AddressDetailsViewModel>> DeleteAddressByIdAsync(Guid userId, Guid addressId)
        {
            if (!_data.Addresses.Any(a => a.Id == addressId))
            {
                throw new ArgumentException(AddressNotFound);
            }

            if(!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentException(UserNotFound);
            }

            var address = await _data.Addresses
                .Where(a => a.CustomerId == userId && a.Id == addressId)
                .FirstOrDefaultAsync();

            if (address == null)
            {
                throw new ArgumentException(AddressNotFound);
            }

            _data.Addresses.Remove(address);
            await _data.SaveChangesAsync();

            return await GetAllAddressesByUserIdAsync(userId);
        }
    }
}
