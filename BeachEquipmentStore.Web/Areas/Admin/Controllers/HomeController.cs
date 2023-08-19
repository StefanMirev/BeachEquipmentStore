using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
