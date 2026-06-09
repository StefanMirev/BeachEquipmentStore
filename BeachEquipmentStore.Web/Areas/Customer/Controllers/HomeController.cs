namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using BeachEquipmentStore.ViewModels.Shared;
    using BeachEquipmentStore.Web.Areas.Customer.ControllerServices.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    [AllowAnonymous]
    public class HomeController : BaseCustomerController
    {
        private readonly IHomeControllerService _homeControllerService;

        public HomeController(IHomeControllerService homeControllerService)
        {
            _homeControllerService = homeControllerService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var result = await _homeControllerService.ResolveHomePageAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.Products);
        }

        [HttpGet]
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
