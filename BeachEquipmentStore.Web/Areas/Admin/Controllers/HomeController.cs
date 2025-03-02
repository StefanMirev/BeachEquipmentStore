namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
