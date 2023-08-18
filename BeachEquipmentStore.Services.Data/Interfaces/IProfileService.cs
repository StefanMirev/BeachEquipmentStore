using BeachEquipmentStore.Services.Data.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface IProfileService
    {
        Task<UserInfoServiceModel> GetUserInfo (Guid userId);

        Task ChangeUserInfo(Guid userId, string firstName, string lastName, string email, string phoneNumber);

        Task<AddressServiceModel> GetAllAddressInfo (Guid userId);

        Task<AddressServiceModel> GetAddressInfo (string addressId);

        Task AddAddress(Guid userId, string name, string town, int zipCode);

        Task ChangeAddressInfo(Guid addressId, string address, string town, int zipCode);

        Task DeleteAddress(Guid addressId);

        Task<List<OrderHistoryServiceModel>> GetOrderHistory(Guid userId);
    }
}
