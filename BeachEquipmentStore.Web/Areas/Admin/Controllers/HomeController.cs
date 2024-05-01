using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        [Area("Admin")]
        [Route("Home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
