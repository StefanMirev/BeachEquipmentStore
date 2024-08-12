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
using System.Text;

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

        [Route("Profile")]
        public async Task<IActionResult> MyProfile()
        {
            try
            {
                var userInfo = await _profiles.GetUserInfo(Guid.Parse(User.GetId()));

                return View(new UserInfoViewModel
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Email = userInfo.Email,
                    PhoneNumber = userInfo.PhoneNumber
                });
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorMessage"] = ex.ParamName;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Route("Edit-Profile")]
        public async Task<IActionResult> EditProfile()
        {
            try
            {
                var userInfo = await _profiles.GetUserInfo(Guid.Parse(User.GetId()));

                return View(new UserInfoViewModel
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Email = userInfo.Email,
                    PhoneNumber = userInfo.PhoneNumber
                });
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorMessage"] = ex.ParamName;

                return RedirectToAction("MyProfile", "Profile");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit-Profile")]
        public async Task<IActionResult> EditProfile(UserInfoViewModel infoModel)
        {
            try
            {
                await _profiles.ChangeUserInfo(Guid.Parse(User.GetId()), infoModel);

                return RedirectToAction("MyProfile", "Profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("EditProfile", "Profile");
            }
        }

        [HttpGet]
        [Route("Change-Password")]
        public IActionResult ChangePassword()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("MyProfile", "Profile");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Change-Password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                var sb = new StringBuilder();

                if (!ModelState.IsValid)
                {
                    foreach(var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }

                    throw new ArgumentException($"{sb.ToString()}");
                }

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        if(error.Description == "Incorrect password.")
                        {
                            sb.AppendLine("Въведената парола не е вярна!");
                        }
                        else
                        {
                            sb.AppendLine(error.Description);
                        }
                    }

                    throw new Exception(sb.ToString());
                }

                TempData["Message"] = "Успешно променихте паролата си!";

                return RedirectToAction("ChangePassword", "Profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("ChangePassword", "Profile");
            }
        }

        [HttpGet]
        [Route("My-Address")]
        public async Task<IActionResult> GetAddress()
        {
            try
            {
                var address = await _profiles.GetAllAddressInfo(Guid.Parse(User.GetId()));

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
                TempData["ErrorMessage"] = ex.Message;

                //TODO: Change it to where it direcly links to add address.
                return View();
            }
        }

        [HttpGet]
        [Route("Add-Address")]
        public IActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        [Route("Add-Address")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(string name, string town, string zipCode)
        {
            try
            {
                await _profiles.AddAddress(Guid.Parse(User.GetId()), name, town, zipCode);

                return RedirectToAction("GetAddress", "Profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("GetAddress", "Profile");
            }
        }

        [HttpGet]
        [Route("Edit-Address")]
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

                return RedirectToAction("MyProfile", "Profile");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit-Address")]
        public async Task<IActionResult> EditAddress(Guid addressId, string name, string town, int zipCode)
        {
            try
            {
                await _profiles.ChangeAddressInfo(addressId, name, town, zipCode);

                return RedirectToAction("GetAddress", "Profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("MyProfile", "Profile");
            }
        }

        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            try
            {
                await _profiles.DeleteAddress(addressId);

                return RedirectToAction("MyProfile", "Profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("MyProfile", "Profile");
            }
        }

        [HttpGet]
        [Route("Order-History")]
        public async Task<IActionResult> OrderHistory()
        {
            try
            {
                List<OrderHistoryServiceModel> orderHistory = await _profiles.GetOrderHistory(Guid.Parse(User.GetId()));

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

                return RedirectToAction("MyProfile", "Profile");
            }
        }
    }
}