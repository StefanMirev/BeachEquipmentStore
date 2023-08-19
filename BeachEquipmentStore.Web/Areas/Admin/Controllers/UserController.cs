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
            return View(await _users.GetAllNotAdminUsers());
        }

        public async Task<IActionResult> UpdateUserRole(Guid userId)
        {
            await _users.MakeAdmin(userId);

            return RedirectToAction("MakeAdmin", "User", new { Area = AdminAreaName});
        }
    }
}
