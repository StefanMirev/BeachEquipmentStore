using BeachEquipmentStore.Services.Data.Models.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface IManufacturerService
    {
        Task<List<ManufacturerServiceModel>> GetAllManufacturersAsync();
    }
}
