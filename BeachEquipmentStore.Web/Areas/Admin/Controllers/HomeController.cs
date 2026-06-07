namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    public class HomeController : BaseAdminController
    {
        [Route("Home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
