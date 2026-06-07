namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class CartController : BaseCustomerController
    {
        private readonly ICartControllerService _cartControllerService;

        public CartController(ICartControllerService cartControllerService)
        {
            _cartControllerService = cartControllerService;
        }

        [HttpGet]
        [Route("Cart")]
        public async Task<IActionResult> Cart()
        {
            var result = await _cartControllerService.GoToCartAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Products);
        }

        [HttpPost]
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Guid productId, int quantity)
        {
            var result = await _cartControllerService.AddToCartAsync(productId, quantity);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = result.ResponseMessage;

            return RedirectToAction("Catalogue", "Product");
        }

        [HttpPost]
        [Route("Clear-Cart")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearCart()
        {
            var result = await _cartControllerService.ClearCartAsync(restoreStock: true);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = result.ResponseMessage;

            return RedirectToAction("Catalogue", "Product");
        }

        [HttpPost]
        [Route("Remove-From-Cart")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid productId)
        {
            var result = await _cartControllerService.RemoveItemFromCartAsync(productId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = result.ResponseMessage;

            return RedirectToAction("Cart", "Cart");
        }
    }
}
