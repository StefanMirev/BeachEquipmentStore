﻿namespace BeachEquipmentStore.Web.Controllers
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Infrastructure.Extensions;
    using BeachEquipmentStore.ViewModels.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class CartController : Controller
    {
        private readonly ICartService _cartItems;
        private readonly IProductService _productService;

        public CartController(ICartService cartItems, IProductService products)
        {
            this._cartItems = cartItems;
            this._productService = products;
        }

        [HttpGet]
        [Route("Cart")]
        public async Task<IActionResult> GoToCart()
        {
            try
            {
                var cartItems = await _cartItems.GetItemsInCart(Guid.Parse(User.GetId()));

                var resultQuery = await _productService.GetProductsInCart(cartItems);

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
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Guid productId, int quantity)
        {
            try
            {
                if (quantity <= 0)
                {
                    throw new ArgumentOutOfRangeException("Трябва да добавите поне една бройка от дадения продукт!");
                }

                if (await _productService.IsInStock(productId, quantity))
                {
                    await _cartItems.AddItemToCart(Guid.Parse(User.GetId()), productId, quantity);

                    TempData["Message"] = "Продуктът бе успешно добавен!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Недостатъчна наличност!";
                }

                return RedirectToAction("All", "Product");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearCart()
        {
            try
            {
                await _cartItems.RemoveAllItemsFromCart(Guid.Parse(User.GetId()));

                return RedirectToAction("All", "Product");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid productId)
        {
            try
            {
                await _cartItems.RemoveItemFromCart(Guid.Parse(User.GetId()), productId);

                return RedirectToAction("GoToCart", "Cart");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}