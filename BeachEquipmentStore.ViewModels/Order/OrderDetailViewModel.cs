using BeachEquipmentStore.Web.ViewModels.Product;
using BeachEquipmentStore.Web.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Web.ViewModels.Order
{
    public class OrderDetailViewModel
    {
        public OrderDetailViewModel()
        {
            this.Products = new List<ExtendedProductViewModel>();
        }

        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        public string DeliveryStatus { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal OverallPrice { get; set; }

        public AddressViewModel Address { get; set; } = null!;

        public List<ExtendedProductViewModel> Products { get; set; }
    }
}
