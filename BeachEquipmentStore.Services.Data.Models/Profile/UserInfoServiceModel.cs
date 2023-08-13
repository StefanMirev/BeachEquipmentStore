using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Models.Profile
{
    public class UserInfoServiceModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
