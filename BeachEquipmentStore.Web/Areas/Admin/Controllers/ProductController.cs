using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Product;
using BeachEquipmentStore.Web.Areas.Admin.ViewModels.Product;
using BeachEquipmentStore.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using static BeachEquipmentStore.Common.GeneralApplicationConstants;

namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private readonly IProductService _products;

        public ProductController(IProductService products)
        {
            _products = products;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Restock()
        {
            List<ProductServiceModel> allProducts = await _products.GetAllProductsAsync();

            return View(new RestockProductsViewModel
            {
                Products = allProducts.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Price = 0,
                    ImageUrl = ""
                })
                .ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> FinishRestock(Guid productId, int quantity)
        {
            await _products.RestockProduct(productId, quantity);

            return RedirectToAction("Restock", "Product", new { Area = AdminAreaName });
        }

    }
}
