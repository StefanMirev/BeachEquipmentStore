using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult GoToCart()
        {
            return View();
        }
    }
}
