namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;

    [Area("Customer")]
    public class BaseCustomerController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity?.IsAuthenticated == true &&
                context.HttpContext.User.IsInRole(AdminRoleName))
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { area = AdminAreaName });
            }

            base.OnActionExecuting(context);
        }
    }
}
