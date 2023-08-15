using BeachEquipmentStore.Web.ViewModels.Product;
using BeachEquipmentStore.Web.ViewModels.Profile;
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

        public  UserInfoViewModel UserInfo { get; set; }
        
        public AddressViewModel? UserAddress { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
