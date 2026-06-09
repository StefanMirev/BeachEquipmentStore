namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class ManufacturerController : BaseCustomerController
    {
        private readonly IManufacturerControllerService _manufacturerControllerService;

        public ManufacturerController(IManufacturerControllerService manufacturerControllerService)
        {
            _manufacturerControllerService = manufacturerControllerService;
        }

        [HttpGet]
        [Route("Manufacturers")]
        public async Task<IActionResult> Manufacturers()
        {
            var result = await _manufacturerControllerService.GetAllManufacturersAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Manufacturers);
        }
    }
}
