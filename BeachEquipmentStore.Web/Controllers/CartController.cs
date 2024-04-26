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
            try
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Guid userId, Guid productId, int quantity)
        {
            try
            {
                string refererUrl = Request.Headers["Referer"].ToString();

                if (quantity <= 0)
                {
                    throw new ArgumentOutOfRangeException("Трябва да добавите поне една бройка от дадения продукт!");
                }

                if (await _products.IsInStock(productId, quantity))
                {
                    await _cartItems.AddItemToCart(userId, productId, quantity);

                    TempData["Message"] = "Продуктът бе успешно добавен!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Недостатъчна наличност!";
                }

                return Redirect(refererUrl);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearCart(Guid userId)
        {
            try
            {
                await _cartItems.RemoveAllItemsFromCart(userId);

                return RedirectToAction("All", "Product");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid userId, Guid productId)
        {
            try
            {
                await _cartItems.RemoveItemFromCart(userId, productId);

                return RedirectToAction("GoToCart", "Cart", new { userId = userId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
