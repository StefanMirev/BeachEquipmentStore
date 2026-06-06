namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class ProductController : BaseCustomerController
    {
        private readonly IProductControllerService _productsControllerService;

        public ProductController(IProductControllerService productsControllerService)
        {
            _productsControllerService = productsControllerService;
        }

        [HttpGet]
        [Route("Product")]
        public async Task<IActionResult> Details(Guid productId)
        {
            var result = await this._productsControllerService.GetProductByIdAsync(productId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Product);
        }

        [HttpGet]
        [Route("Catalogue")]
        public async Task<IActionResult> Catalogue(string keyword, int categoryId, int manufacturerId)
        {
            var result = await _productsControllerService.GetFilteredProductsAsync(keyword, categoryId, manufacturerId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Products);
        }
    }
}
