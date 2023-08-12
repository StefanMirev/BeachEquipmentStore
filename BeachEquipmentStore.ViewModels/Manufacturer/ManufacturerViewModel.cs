using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Web.ViewModels.Manufacturer
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; } = null!;
    }
}
