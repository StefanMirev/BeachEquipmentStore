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
        Task<MyProfileServiceModel> GetUserInfo (string userId);

        Task<MyProfileServiceModel> ChangeUserInfo(string firstName, string lastName, string email, string phoneNumber);

        Task<PasswordServiceModel> ChangePassword (string currentPassword, string newPasswordHash, string newPasswordConfirmation);

        Task<AddressServiceModel> GetAddressInfo (string userId);

        Task<AddressServiceModel> ChangeAddressInfo(string address, string town, string zipCode);

        Task<OrderHistoryServiceModel> GetOrderHistory(string userId);
    }
}
