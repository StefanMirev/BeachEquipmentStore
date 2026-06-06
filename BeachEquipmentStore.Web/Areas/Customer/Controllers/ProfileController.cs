namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using BeachEquipmentStore.ViewModels.Profile;
    using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class ProfileController : BaseCustomerController
    {
        private readonly IUserControllerService _profileControllerService;

        public ProfileController(IUserControllerService profileControllerService)
        {
            _profileControllerService = profileControllerService;
        }

        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> MyProfile()
        {
            var result = await _profileControllerService.GetUserDetailsAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.UserDetails);
        }

        [HttpGet]
        [Route("Edit-Profile")]
        public async Task<IActionResult> EditProfile()
        {
            var result = await _profileControllerService.GetUserDetailsAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("MyProfile", "Profile");
            }

            return View(result.UserDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit-Profile")]
        public async Task<IActionResult> EditProfile(UserDetailsViewModel userDetails)
        {
            var result = await _profileControllerService.ChangeUserDetailsAsync(userDetails);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("EditProfile", "Profile");
            }

            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpGet]
        [Route("Change-Password")]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Change-Password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }

            var result = await _profileControllerService.ChangeUserPasswordAsync(model);

            if (!result.UserFound)
            {
                return NotFound();
            }

            TempData[result.IsSuccess ? "Message" : "ErrorMessage"] = result.ResponseMessage;

            return RedirectToAction("ChangePassword", "Profile");
        }

        [HttpGet]
        [Route("My-Addresses")]
        public async Task<IActionResult> Addresses()
        {
            var result = await _profileControllerService.GetAllUserAddressesAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("AddAddress", "Profile");
            }

            return View(result.Addresses);
        }

        [HttpGet]
        [Route("Add-Address")]
        public async Task<IActionResult> AddAddress()
        {
            return View();
        }

        [HttpPost]
        [Route("Add-Address")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(string name, string town, string zipCode, bool isPrimaryAddress)
        {
            var result = await _profileControllerService.AddUserAddressAsync(name, town, zipCode, isPrimaryAddress);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;
            }

            return RedirectToAction("Addresses", "Profile");
        }

        [HttpGet]
        [Route("Edit-Address")]
        public async Task<IActionResult> EditAddress(string addressId)
        {
            var result = await _profileControllerService.GetUserAddressDetailsAsync(addressId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("MyProfile", "Profile");
            }

            return View(result.Address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit-Address")]
        public async Task<IActionResult> EditAddress(Guid addressId, string name, string town, string zipCode)
        {
            var result = await _profileControllerService.ChangeUserAddressDetailsAsync(addressId, name, town, zipCode);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("MyProfile", "Profile");
            }

            return RedirectToAction("Addresses", "Profile");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Delete-Address")]
        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            var result = await _profileControllerService.DeleteUserAddressAsync(addressId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("MyProfile", "Profile");
            }

            if (result.RemainingCount > 0)
            {
                return RedirectToAction("Addresses", "Profile");
            }

            return RedirectToAction("AddAddress", "Profile");
        }

        [HttpGet]
        [Route("Order-History")]
        public async Task<IActionResult> OrderHistory()
        {
            var result = await _profileControllerService.GetUserOrderHistoryAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("MyProfile", "Profile");
            }

            return View(result.Orders);
        }
    }
}
