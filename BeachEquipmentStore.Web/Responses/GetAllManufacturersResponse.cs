namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Manufacturer;

    public class GetAllManufacturersResponse : BaseResponse
    {
        public List<ManufacturerViewModel> Manufacturers { get; set; } = new();
    }
}
