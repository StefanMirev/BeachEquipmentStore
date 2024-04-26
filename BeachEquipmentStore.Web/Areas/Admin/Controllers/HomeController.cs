using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
