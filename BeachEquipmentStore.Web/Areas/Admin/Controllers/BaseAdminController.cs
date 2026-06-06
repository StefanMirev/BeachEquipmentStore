namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {

    }
}
