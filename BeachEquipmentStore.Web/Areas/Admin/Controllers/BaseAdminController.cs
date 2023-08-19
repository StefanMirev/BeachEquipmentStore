using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static BeachEquipmentStore.Common.GeneralApplicationConstants;

namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
        
    }
}
