using BeachEquipmentStore.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BeachEquipmentStore.Common.GeneralApplicationConstants;

namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    public class OrderController : BaseAdminController
    {
        private readonly IOrderService _orders;

        public OrderController(IOrderService orders)
        {
            _orders = orders;
        }

        [HttpGet]
        public async Task<IActionResult> Deliver()
        {
            return View(await _orders.GetUndeliveredOrders());
        }

        [HttpPost]
        public async Task<IActionResult> CompleteDelivery(Guid orderId)
        {
            await _orders.DeliverORders(orderId);

            return RedirectToAction("Deliver", "Order", new { Area = AdminAreaName });
        }
    }
}
