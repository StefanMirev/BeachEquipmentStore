namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class ProductController : BaseCustomerController
    {
        private readonly IProductControllerService _productControllerService;

        public ProductController(IProductControllerService productControllerService)
        {
            _productControllerService = productControllerService;
        }

        [HttpGet]
        [Route("Product")]
        public async Task<IActionResult> Details(Guid productId)
        {
            var result = await this._productControllerService.GetProductByIdAsync(productId);

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
            var result = await _productControllerService.GetFilteredProductsAsync(keyword, categoryId, manufacturerId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Products);
        }
    }
}
