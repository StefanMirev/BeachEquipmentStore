namespace BeachEquipmentStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("[action]")]
    public class ErrorController : Controller
    {
        [HttpGet]
        [ActionName("NotFound")]
        public IActionResult PageNotFound() => View("NotFound");
    }
}
