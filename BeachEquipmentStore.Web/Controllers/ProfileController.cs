using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Web.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            return View(new MyProfileViewModel
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Email = userInfo.Email,
                PhoneNumber = userInfo.PhoneNumber
            });
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult EditAddress()
        {
            return View();
        }

        public IActionResult OrderHistory()
        {
            return View();
        }
    }
}
