using BeachEquipmentStore.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Web.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            this.Products = new List<ProductViewModel>();    
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? AddressName { get; set; }

        public string? Town { get; set; }

        public int? ZipCode { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
