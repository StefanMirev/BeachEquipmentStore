using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Controllers
{
    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class CartController : Controller
    {
        private readonly ICartService _cartItems;
        private readonly IProductService _products;

        public CartController(ICartService cartItems, IProductService products)
        {
            this._cartItems = cartItems;
            this._products = products;
        }

        public async Task<IActionResult> GoToCart(Guid userId)
        {
            var cartItems = await _cartItems.GetItemsInCart(userId);

            var resultQuery = await _products.GetProductsInCart(cartItems);

            List<ProductViewModel> productsInCart = resultQuery
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .ToList();

            return View(productsInCart);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Guid userId, Guid productId, int quantity)
        {
            string refererUrl = Request.Headers["Referer"].ToString();

            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Can't add less than one product in cart!");
            }

            if (await _products.IsInStock(productId, quantity))
            {
                await _cartItems.AddItemToCart(userId, productId, quantity);

                TempData["Message"] = "Продуктът бе успешно добавен!";
            }
            else
            {
                TempData["ErrorMessage"] = "Продуктът не е в наличност!";
            }

            return Redirect(refererUrl);
        }

        public async Task<IActionResult> ClearCart(Guid userId)
        {
            await _cartItems.RemoveAllItemsFromCart(userId);

            return RedirectToAction("All", "Product");
        }

        public async Task<IActionResult> Remove(Guid userId, Guid productId)
        {
            await _cartItems.RemoveItemFromCart(userId, productId);

            return RedirectToAction("GoToCart", "Cart", new { userId = userId});
        }
    }
}
