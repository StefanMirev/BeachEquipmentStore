namespace BeachEquipmentStore.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    
    using BeachEquipmentStore.Web.ViewModels.Home;
    using BeachEquipmentStore.Services.Data.Interfaces;
    using BeachEquipmentStore.Data;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductService _products;

        public HomeController(IProductService products)
        {
            _products = products;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<IndexViewModel> randomProducts = await this._products.GetNineRandomProductsInStockAsync();

            return View(randomProducts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> About()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Contact()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}