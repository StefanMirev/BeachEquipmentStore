﻿using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Services.Data;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Product;
using BeachEquipmentStore.Services.Data.Models.Profile;
using BeachEquipmentStore.Web.ViewModels.Order;
using BeachEquipmentStore.Web.ViewModels.Product;
using BeachEquipmentStore.Web.ViewModels.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BeachEquipmentStore.Common.EntityValidationConstants;

namespace BeachEquipmentStore.Web.Controllers
{
    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orders;
        private readonly ICartService _cart;
        private readonly IProfileService _profile;

        public OrderController(IOrderService orders, ICartService cart, IProfileService profile)
        {
            _orders = orders;
            _cart = cart;
            _profile = profile;
        }

        [HttpGet]
        [Route("Create-Order")]
        public async Task<IActionResult> CreateOrder(Guid userId)
        {
            try
            {
                var orderServiceData = await _orders.GetDataRequiredForOrder(userId);

                bool hasAddress = !string.IsNullOrEmpty(orderServiceData.UserAddress?.Name);
                ViewBag.HasAddress = hasAddress;

                decimal? sumOfAllProducts = orderServiceData.Products.Sum(p => p.Price * p.Quantity);
                ViewBag.FormattedSum = string.Format("{0:C}", sumOfAllProducts);

                return View(new CreateOrderViewModel
                {
                    UserInfo = new UserInfoViewModel
                    {
                        FirstName = orderServiceData.UserInfo.FirstName,
                        LastName = orderServiceData.UserInfo.LastName,
                        Email = orderServiceData.UserInfo.Email,
                        PhoneNumber = orderServiceData.UserInfo.PhoneNumber,
                    },
                    UserAddress = new AddressViewModel
                    {
                        Name = orderServiceData.UserAddress!.Name,
                        Town = orderServiceData.UserAddress!.Town,
                        ZipCode = orderServiceData.UserAddress.ZipCode
                    },
                    Products = new List<ProductViewModel>(orderServiceData.Products.Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        Quantity = p.Quantity
                    }))
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(Guid userId, bool hasAddress, string? addressName, string? town, int zipCode, decimal totalSum)
        {
            try
            {
                await _orders.GenerateOrder(userId, hasAddress, addressName, town, zipCode, totalSum);
                await _cart.ClearCartAfterOrder(userId);
                return RedirectToAction("OrderHistory", "Profile", new { userId = userId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Details(string orderId)
        {
            try
            {
                var detailsModel = await _orders.GetOrderDetails(orderId);

                return View(new OrderDetailViewModel
                {
                    Id = detailsModel.Id,
                    OrderDate = detailsModel.OrderDate,
                    ShippingDate = detailsModel.ShippingDate,
                    DeliveryStatus = detailsModel.DeliveryStatus,
                    DeliveryPrice = detailsModel.DeliveryPrice,
                    OverallPrice = detailsModel.TotalPrice,
                    TotalPrice = detailsModel.TotalPrice - detailsModel.DeliveryPrice,
                    AddressName = detailsModel.AddressName,
                    TownName = detailsModel.TownName,
                    ZipCode = detailsModel.ZipCode,
                    Products = detailsModel.Products.Select(p => new ExtendedProductViewModel
                    {
                        Name = p.Name,
                        Barcode = p.Barcode,
                        Price = p.Price,
                        Stock = p.Stock
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
