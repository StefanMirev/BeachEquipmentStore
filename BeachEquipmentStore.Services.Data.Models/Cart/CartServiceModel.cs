using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Models.Cart
{
    public class CartServiceModel
    {  
        public Guid ProductId { get; set; }
      
        public int Quantity { get; set; }
    }
}
