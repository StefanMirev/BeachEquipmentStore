using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
