namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : BaseCustomerController
    {
        private readonly ICategoryControllerService _categoryControllerService;

        public CategoryController(ICategoryControllerService categoryControllerService)
        {
            _categoryControllerService = categoryControllerService;
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<IActionResult> Categories()
        {
            var result = await _categoryControllerService.GetAllCategoriesAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Categories);
        }
    }
}
