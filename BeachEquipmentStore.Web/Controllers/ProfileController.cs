namespace BeachEquipmentStore.Web.Controllers
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Infrastructure.Extensions;
    using BeachEquipmentStore.ViewModels.Profile;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Text;

    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class ProfileController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public ProfileController(IAddressService addressService, IOrderService orderService, IUserService userService)
        {
            _addressService = addressService;
            _orderService = orderService;
            _userService = userService;
        }

        [Route("Profile")]
        public async Task<IActionResult> MyProfile()
        {
            try
            {
                var userDetails = await _userService.GetUserDetails(Guid.Parse(User.GetId()));

                return View(new UserDetailsViewModel
                {
                    FirstName = userDetails.FirstName,
                    LastName = userDetails.LastName,
                    Email = userDetails.Email,
                    PhoneNumber = userDetails.PhoneNumber
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
                var userDetails = await _userService.GetUserDetails(Guid.Parse(User.GetId()));

                return View(new UserDetailsViewModel
                {
                    FirstName = userDetails.FirstName,
                    LastName = userDetails.LastName,
                    Email = userDetails.Email,
                    PhoneNumber = userDetails.PhoneNumber
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
        public async Task<IActionResult> EditProfile(UserDetailsViewModel userDetails)
        {
            try
            {
                await _userService.ChangeUserDetails(Guid.Parse(User.GetId()), userDetails);

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
                var user = await _userService.GetCurrentUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                var sb = new StringBuilder();

                if (!ModelState.IsValid)
                {
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }

                    throw new ArgumentException($"{sb.ToString()}");
                }

                var changePasswordResult = await _userService.ChangeUserPasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        if (error.Description == "Incorrect password.")
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
        [Route("My-Addresses")]
        public async Task<IActionResult> GetAddresses()
        {
            try
            {
                var addresses = await _addressService.GetAllAddresses(Guid.Parse(User.GetId()));
                
                return View(addresses);
            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("AddAddress", "Profile");
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("AddAddress", "Profile");
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
        public async Task<IActionResult> AddAddress(string name, string town, string zipCode, bool? isPrimaryAddress)
        {
            try
            {
                await _addressService.AddAddress(Guid.Parse(User.GetId()), name, town, zipCode, isPrimaryAddress);

                return RedirectToAction("GetAddresses", "Profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("GetAddresses", "Profile");
            }
        }

        [HttpGet]
        [Route("Edit-Address")]
        public async Task<IActionResult> EditAddress(string addressId)
        {
            try
            {
                var addresses = await _addressService.GetAddressDetails(addressId);

                return View(new AddressDetailsViewModel
                {
                    Id = addresses.Id,
                    Name = addresses.Name,
                    Town = addresses.Town,
                    ZipCode = addresses.ZipCode,
                    IsPrimaryAddress = addresses.IsPrimaryAddress
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
        public async Task<IActionResult> EditAddress(Guid addressId, string name, string town, string zipCode)
        {
            try
            {
                await _addressService.ChangeAddressDetails(addressId, name, town, zipCode);

                return RedirectToAction("GetAddresses", "Profile");
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
                var addresses = await _addressService.DeleteAddress(Guid.Parse(User.GetId()), addressId);

                if (addresses.Any())
                {
                    return RedirectToAction("GetAddresses", "Profile");
                }

                return RedirectToAction("AddAddress", "Profile");
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
                List<OrderHistoryViewModel> orderHistory = await _orderService.GetOrderHistory(Guid.Parse(User.GetId()));

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