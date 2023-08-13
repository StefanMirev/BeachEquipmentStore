using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Web.ViewModels.Profile
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
       
        public string Town { get; set; } = null!;

        public int ZipCode { get; set; }
    }
}
