using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices
{
    public class ManufacturerControllerService : IManufacturerControllerService
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerControllerService(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        public async Task<GetAllManufacturersResponse> GetAllManufacturersAsync()
        {
            try
            {
                var manufacturers = await _manufacturerService.GetAllManufacturersAsync();

                return new GetAllManufacturersResponse
                {
                    IsSuccess = true,
                    Manufacturers = manufacturers
                };
            }
            catch (Exception ex)
            {
                return new GetAllManufacturersResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }
    }
}
