using BeachEquipmentStore.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BeachEquipmentStore.Common.GeneralApplicationConstants;

namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService _users;

        public UserController(IUserService users)
        {
            _users = users;
        }

        public async Task<IActionResult> MakeAdmin()
        {
            try
            {
                return View(await _users.GetAllNotAdminUsers());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> UpdateUserRole(Guid userId)
        {
            try
            {
                await _users.MakeAdmin(userId);

                return RedirectToAction("MakeAdmin", "User", new { Area = AdminAreaName });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
