namespace BeachEquipmentStore.Services.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Profile;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class AddressService : IAddressService
    {
        private readonly EquipmentStoreDbContext _data;

        public AddressService(EquipmentStoreDbContext data, UserManager<ApplicationUser> userManager)
        {
            this._data= data;
        }

        public async Task<List<AddressDetailsViewModel>> GetAllAddresses(Guid userId)
        {
            if (!await _data.Users.AnyAsync(a => a.Id == userId))
            {
                throw new ArgumentException("Потребителят не съществува!");
            }

            if (!await _data.Addresses.AnyAsync(a => a.CustomerId == userId))
            {
                throw new InvalidOperationException("Все още нямате адрес!");
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

        public async Task<AddressDetailsViewModel> GetAddressDetails(string addressId)
        {
            if (!await _data.Addresses.AnyAsync(a => a.Id == Guid.Parse(addressId)))
            {
                throw new InvalidOperationException("Все още нямате адрес!");
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

        public async Task AddAddress(Guid userId, string name, string town, string zipCode, bool? isPrimaryAddress)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentNullException("Потребителят не съществува!");
            }

            if (_data.Addresses.Where(a => a.CustomerId == userId).Count() >= 10)
            {
                throw new InvalidOperationException("Максималният позволен брой адреси е 10. За да добавите друг, моля първо изтрийте един от съществуващите!");
            }

            if (!int.TryParse(zipCode, out int result))
            {
                throw new ArgumentException("Моля въведете валиден пощенски код!");
            }

            var isPrimary = isPrimaryAddress ?? false;

            if (isPrimary)
            {
                var primaryAddresses = _data.Addresses.Where(a => a.IsPrimaryAddress == true);

                foreach (var primaryAddress in primaryAddresses)
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
                IsPrimaryAddress = isPrimary,
                CreatedAt = DateTime.Now,
                CustomerId = userId
            };

            _data.Addresses.Add(address);
            await _data.SaveChangesAsync();
        }

        public async Task ChangeAddressDetails(Guid addressId, string name, string town, string zipCode)
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

        public async Task<List<AddressDetailsViewModel>> DeleteAddress(Guid userId, Guid addressId)
        {
            if (!_data.Addresses.Any(a => a.Id == addressId))
            {
                throw new InvalidOperationException("Адресът не съществува!");
            }

            var addresses = await _data.Addresses
            .Where(a => a.CustomerId == userId)
            .ToListAsync();

            _data.Addresses.Remove(addresses.SingleOrDefault(a => a.Id == addressId)!);
            await _data.SaveChangesAsync();

            addresses.Remove(addresses.SingleOrDefault(a => a.Id == addressId)!);

            return addresses.Select(a => new AddressDetailsViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Town = a.Town,
                ZipCode = a.ZipCode,
                IsPrimaryAddress = a.IsPrimaryAddress
            }).ToList();
        }
    }
}
