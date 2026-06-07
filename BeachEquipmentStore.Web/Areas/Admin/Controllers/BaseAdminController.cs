namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Policy = "AdminArea")]
    public class BaseAdminController : Controller
    {
    }
}
