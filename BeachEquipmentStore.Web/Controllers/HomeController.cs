namespace BeachEquipmentStore.Web.Controllers
{
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Data.Interfaces;
    using BeachEquipmentStore.Web.Infrastructure.Extensions;
    using BeachEquipmentStore.Web.ViewModels.Home;
    using BeachEquipmentStore.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static BeachEquipmentStore.Common.GeneralApplicationConstants;

    public class HomeController : Controller
    {
        private readonly IProductService _products;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IProductService products, UserManager<ApplicationUser> userManager)
        {
            _products = products;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                if (User.IsAdmin())
                {
                    var adminUrl = Url.Action("Index", "Home", new { area = AdminAreaName });
                    return Redirect(adminUrl!);
                }

                ExtendendedFiltrationViewModel resultsetOfProducts = new ExtendendedFiltrationViewModel()
                {
                    FilteredProducts = new FilterProductsViewModel()
                    {
                        Products = new List<ProductViewModel>()
                    }
                };

                var randomisedProducs = await this._products.GetRandomProductsInStockAsync();

                resultsetOfProducts.FilteredProducts.Products.AddRange(randomisedProducs.Select(p => new ProductViewModel
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
        public IActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Contact()
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