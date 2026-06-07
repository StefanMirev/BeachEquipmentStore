namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using BeachEquipmentStore.Web.Areas.Admin.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;

    [Area("Admin")]
    public class UserController : BaseAdminController
    {
        private readonly IUserControllerService _userControllerService;

        public UserController(IUserControllerService userControllerService)
        {
            _userControllerService = userControllerService;
        }

        [HttpGet]
        [Route("Make-Admin")]
        public async Task<IActionResult> MakeAdmin()
        {
            var result = await _userControllerService.GetAllNonAdminUsersAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserRole(Guid userId)
        {

            var result = await _userControllerService.MakeAdminAsync(userId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;
            }
            else
            {
                TempData["Message"] = result.ResponseMessage;
            }

            return RedirectToAction("MakeAdmin", "User", new { Area = AdminAreaName });
        }
    }
}
