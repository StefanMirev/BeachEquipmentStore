using BeachEquipmentStore.Services.Data.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Models.Product
{
    public class ExtendedFiltrationServiceModel
    {
        public string Keyword { get; set; } = null!;

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public FilterProductsServiceModel FilteredProducts { get; set; } = null!;
    }
}
