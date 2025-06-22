namespace BeachEquipmentStore.Web.Controllers
{
    using BeachEquipmentStore.Services.Interfaces;
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

            return View(allManufacturers);
        }
    }
}
