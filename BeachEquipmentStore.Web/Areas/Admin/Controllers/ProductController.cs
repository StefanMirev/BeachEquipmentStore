namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;
    using BeachEquipmentStore.Web.Areas.Admin.Interfaces;

    [Area("Admin")]
    public class ProductController : BaseAdminController
    {
        private readonly IProductControllerService _productControllerService;

        public ProductController(IProductControllerService productControllerService)
        {
            _productControllerService = productControllerService;
        }

        [HttpGet]
        [Route("Restock")]
        public async Task<IActionResult> Restock()
        {

            var result = await _productControllerService.GetAllProductsAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinishRestock(Guid productId, int quantity)
        {

            var result = await _productControllerService.RestockProductAsync(productId, quantity);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;
            }

            return RedirectToAction("Restock", "Product", new { Area = AdminAreaName });
        }
    }

}