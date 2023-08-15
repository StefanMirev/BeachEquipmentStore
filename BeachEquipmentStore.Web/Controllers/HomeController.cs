namespace BeachEquipmentStore.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    
    using BeachEquipmentStore.Web.ViewModels.Home;
    using BeachEquipmentStore.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using BeachEquipmentStore.Web.ViewModels.Product;

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
            List<ProductViewModel> resultsetOfProducts = new List<ProductViewModel>();

            var randomisedProducs = await this._products.GetRandomProductsInStockAsync();

            resultsetOfProducts.AddRange(randomisedProducs.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price

            }));

            return View(resultsetOfProducts);
        }

        [AllowAnonymous]
        public  IActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        public  IActionResult Contact()
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