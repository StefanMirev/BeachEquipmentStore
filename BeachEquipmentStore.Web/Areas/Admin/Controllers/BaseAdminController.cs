namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static BeachEquipmentStore.Common.GeneralApplicationConstants;

    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {

    }
}
