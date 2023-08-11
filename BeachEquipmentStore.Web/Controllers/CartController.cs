using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartItems;
        private readonly IProductService _products;

        public CartController(ICartService cartItems, IProductService products)
        {
            this._cartItems = cartItems;
            this._products = products;
        }

        public async Task<IActionResult> GoToCart(Guid customerId)
        {
            var cartItems = await _cartItems.GetItemsInCart(customerId);

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
        public async Task<IActionResult> Add(Guid customerId, Guid productId, int quantity)
        {
            await _cartItems.AddItemToCart(customerId, productId, quantity);

            string refererUrl = Request.Headers["Referer"].ToString();

            return Redirect(refererUrl);
        }
    }
}
