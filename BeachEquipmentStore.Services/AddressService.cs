namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Profile;
    using Microsoft.EntityFrameworkCore;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class AddressService : IAddressService
    {
        private readonly AllBusinessLogics _allBls;

        public AddressService(AllBusinessLogics allBls)
        {
            _allBls = allBls;
        }

        public async Task<List<AddressDetailsViewModel>> GetAllAddressesByUserIdAsync(Guid userId)
        {
            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
            {
                throw new ArgumentException(UserNotFound);
            }

            var addresses = await _allBls.AddressesBL.GetAllAsync(a => a.CustomerUserId == userId);

            if (!addresses.Any())
            {
                throw new InvalidOperationException(AddressNotFound);
            }

            return addresses
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
                .ToList();
        }

        public async Task<AddressDetailsViewModel> GetAddressDetailsByIdAsync(Guid addressId)
        {
            var address = await _allBls.AddressesBL.FindAsNoTrackingAsync(addressId);

            if (address == null)
            {
                throw new InvalidOperationException(AddressNotFound);
            }

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
            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
                throw new ArgumentException(UserNotFound);

            var userAddresses = await _allBls.AddressesBL.GetAllAsync(a => a.CustomerUserId == userId);

            if (userAddresses.Count >= 10)
                throw new InvalidOperationException(AddressLimitReached);

            if (!int.TryParse(zipCode, out int _))
                throw new ArgumentException(AddressZipCodeInvalid);

            using var transaction = _allBls.AddressesBL.GetTransactionProxy();
            try
            {
                if (isPrimaryAddress)
                {
                    var primaryAddress = await _allBls.AddressesBL.AsQueryable()
                        .FirstOrDefaultAsync(a => a.IsPrimaryAddress);

                    if (primaryAddress != null)
                        primaryAddress.IsPrimaryAddress = false;
                }

                var address = new Address
                {
                    Name = name,
                    Town = town,
                    ZipCode = zipCode,
                    IsPrimaryAddress = isPrimaryAddress,
                    CreatedAt = DateTime.Now,
                    CustomerUserId = userId
                };

                await _allBls.AddressesBL.AddAsync(address);
                await _allBls.AddressesBL.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateAddressByIdAsync(Guid addressId, string name, string town, string zipCode)
        {
            using var transaction = _allBls.AddressesBL.GetTransactionProxy();
            try
            {
                var addressToChange = await _allBls.AddressesBL.FindAsync(addressId)
                    ?? throw new InvalidOperationException(AddressNotFound);

                addressToChange.Name = name;
                addressToChange.Town = town;
                addressToChange.ZipCode = zipCode;

                await _allBls.AddressesBL.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<AddressDetailsViewModel>> DeleteAddressByIdAsync(Guid userId, Guid addressId)
        {
            using var transaction = _allBls.AddressesBL.GetTransactionProxy();
            try
            {
                var address = await _allBls.AddressesBL.FindAsync(addressId)
                    ?? throw new ArgumentException(AddressNotFound);

                if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
                    throw new ArgumentException(UserNotFound);

                if (address.CustomerUserId != userId)
                    throw new ArgumentException(AddressNotFound);

                _allBls.AddressesBL.Remove(address);
                await _allBls.AddressesBL.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            return await GetAllAddressesByUserIdAsync(userId);
        }
    }
}
