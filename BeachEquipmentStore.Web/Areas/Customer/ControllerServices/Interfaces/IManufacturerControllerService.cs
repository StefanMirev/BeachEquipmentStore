using BeachEquipmentStore.Web.Responses;

namespace BeachEquipmentStore.Web.Areas.Customer.ControllerServices.Interfaces
{
    public interface IManufacturerControllerService
    {
        Task<GetAllManufacturersResponse> GetAllManufacturersAsync();
    }
}
