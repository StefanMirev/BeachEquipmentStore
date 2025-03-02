namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using BeachEquipmentStore.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using static BeachEquipmentStore.Common.GeneralApplicationConstants;

    [Area("Admin")]
    public class OrderController : BaseAdminController
    {
        private readonly IOrderService _orders;

        public OrderController(IOrderService orders)
        {
            _orders = orders;
        }

        [HttpGet]
        [Route("Delivery-Status")]
        public async Task<IActionResult> Deliver()
        {
            try
            {
                return View(await _orders.GetUndeliveredOrders());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CompleteDelivery(Guid orderId)
        {
            try
            {
                await _orders.DeliverOrders(orderId);

                return RedirectToAction("Deliver", "Order", new { Area = AdminAreaName });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
