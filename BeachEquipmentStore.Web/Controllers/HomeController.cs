namespace BeachEquipmentStore.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    
    using BeachEquipmentStore.Web.ViewModels.Home;
    using BeachEquipmentStore.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using BeachEquipmentStore.Web.ViewModels.Product;

    using static BeachEquipmentStore.Common.GeneralApplicationConstants;
    using BeachEquipmentStore.Web.Infrastructure.Extensions;

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
            try { 
            if (User.IsInRole(AdminRoleName))
            {
                var adminUrl = Url.Action("Index", "Home", new { area = AdminAreaName });
                return Redirect(adminUrl);
            }

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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
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