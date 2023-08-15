﻿using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Profile;
using BeachEquipmentStore.Web.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

namespace BeachEquipmentStore.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profiles;

        public ProfileController(IProfileService profiles)
        {
            _profiles = profiles;
        }

        public async Task<IActionResult> MyProfile(string userId)
        {
            var userInfo = await _profiles.GetUserInfo(userId);

            return View(new UserInfoViewModel
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Email = userInfo.Email,
                PhoneNumber = userInfo.PhoneNumber
            });
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(string userId)
        {
            var userInfo = await _profiles.GetUserInfo(userId);

            return View(new UserInfoViewModel
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Email = userInfo.Email,
                PhoneNumber = userInfo.PhoneNumber
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(string userId, string firstName, string lastName, string email, string phoneNumber)
        {
            await _profiles.ChangeUserInfo(userId, firstName, lastName, email, phoneNumber);

            return RedirectToAction("MyProfile", "Profile", new { userId = userId });
        }

        [HttpGet]
        public  IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string userId, string currentPassword, string newPassword, string confirmPassword)
        {
            try
            {
                await this._profiles.ChangePassword(userId, currentPassword, newPassword, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ChangePassword", "Profile");
            }

            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpGet]
        public async Task<IActionResult> GetAddress(string userId)
        {
            var addresses = await _profiles.GetAllAddressesInfo(userId);

            return View(addresses.Select(a => new AddressViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Town = a.Town,
                ZipCode = a.ZipCode
            }).ToList());
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(string userId, string name, string town, int zipCode)
        {
            await _profiles.AddAddress(userId, name, town, zipCode);

            return RedirectToAction("MyProfile", "Profile", new { userId = userId });
        }

        [HttpGet]
        public async Task<IActionResult> EditAddress(string addressId)
        {
            var addresses = await _profiles.GetAddressInfo(addressId);

            return View(new AddressViewModel
            {
                Id = addresses.Id,
                Name = addresses.Name,
                Town = addresses.Town,
                ZipCode = addresses.ZipCode
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditAddress(string userId, Guid addressId, string name, string town, int zipCode)
        {
            await _profiles.ChangeAddressInfo(addressId, name, town, zipCode);

            return RedirectToAction("GetAddress","Profile", new { userId = userId} );
        }

        public async Task<IActionResult> DeleteAddress(Guid addressId, string userId)
        {
            await _profiles.DeleteAddress(addressId);

            return RedirectToAction("MyProfile", "Profile", new { userId = userId });
        }

        [HttpGet]
        public async Task<IActionResult> OrderHistory(string userId)
        {
            List<OrderHistoryServiceModel> orderHistory = await _profiles.GetOrderHistory(userId);

            return View(orderHistory
                .Select(o => new OrderHistoryViewModel
                {
                    Id = o.Id,
                    DeliveryStatus = o.DeliveryStatus,
                    OrderDate = o.OrderDate,
                    TotalPrice = o.TotalPrice
                }).ToList());
        }
    }
}
