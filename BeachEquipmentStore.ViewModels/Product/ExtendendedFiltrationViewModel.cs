using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Web.ViewModels.Product
{
    public class ExtendendedFiltrationViewModel
    {
        public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public FilterProductsViewModel FilteredProducts { get; set; } = null!;
    }
}
