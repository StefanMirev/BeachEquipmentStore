using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Profile;
using BeachEquipmentStore.Web.Infrastructure.Extensions;
using BeachEquipmentStore.Web.ViewModels.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

namespace BeachEquipmentStore.Web.Controllers
{
    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profiles;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(IProfileService profiles, UserManager<ApplicationUser> userManager)
        {
            _profiles = profiles;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyProfile(Guid userId)
        {
            try
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(Guid userId)
        {
            try
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(Guid userId, UserInfoViewModel infoModel)
        {
            try
            {
                await _profiles.ChangeUserInfo(userId, infoModel);

                return RedirectToAction("MyProfile", "Profile", new { userId = userId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

                return RedirectToAction("MyProfile", "Profile", new { userId = Guid.Parse(User.GetId()) });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAddress(Guid userId)
        {
            try
            {
                var address = await _profiles.GetAllAddressInfo(userId);

                return View(new AddressViewModel
                {
                    Id = address.Id,
                    Name = address.Name,
                    Town = address.Town,
                    ZipCode = address.ZipCode
                });
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(Guid userId, string name, string town, int zipCode)
        {
            try
            {
                await _profiles.AddAddress(userId, name, town, zipCode);

                return RedirectToAction("GetAddress", "Profile", new { userId = userId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAddress(string addressId)
        {
            try
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAddress(Guid userId, Guid addressId, string name, string town, int zipCode)
        {
            try
            {
                await _profiles.ChangeAddressInfo(addressId, name, town, zipCode);

                return RedirectToAction("GetAddress", "Profile", new { userId = userId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> DeleteAddress(Guid addressId, Guid userId)
        {
            try
            {
                await _profiles.DeleteAddress(addressId);

                return RedirectToAction("MyProfile", "Profile", new { userId = userId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderHistory(Guid userId)
        {
            try
            {
                List<OrderHistoryServiceModel> orderHistory = await _profiles.GetOrderHistory(userId);

                return View(orderHistory
                    .Select(o => new OrderHistoryViewModel
                    {
                        Id = o.Id,
                        DeliveryStatus = o.DeliveryStatus,
                        OrderDate = o.OrderDate,
                        TotalPrice = o.TotalPrice
                    })
                    .OrderByDescending(oh => oh.OrderDate)
                    .ToList());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}