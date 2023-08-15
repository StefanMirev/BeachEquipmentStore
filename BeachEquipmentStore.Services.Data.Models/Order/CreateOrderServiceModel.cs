using BeachEquipmentStore.Services.Data.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Models.Order
{
    public class CreateOrderServiceModel
    {
        public CreateOrderServiceModel()
        {
            this.Products = new List<ProductServiceModel>();
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set;} = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? AddressName { get; set; }

        public string? Town { get; set; }

        public int? ZipCode { get; set; }

        public List<ProductServiceModel> Products { get; set; } 
    }
}
