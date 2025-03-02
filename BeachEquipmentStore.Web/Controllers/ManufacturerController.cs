namespace BeachEquipmentStore.Web.Controllers
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Manufacturer;
    using Microsoft.AspNetCore.Mvc;

    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturers;

        public ManufacturerController(IManufacturerService manufacturers)
        {
            this._manufacturers = manufacturers;
        }

        [Route("Manufacturers")]
        public async Task<IActionResult> AllManufacturers()
        {
            var allManufacturers = await _manufacturers.GetAllManufacturersAsync();

            List<ManufacturerViewModel> resultManufacturers = allManufacturers
                .Select(m => new ManufacturerViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                })
                .ToList();

            return View(resultManufacturers);
        }
    }
}
