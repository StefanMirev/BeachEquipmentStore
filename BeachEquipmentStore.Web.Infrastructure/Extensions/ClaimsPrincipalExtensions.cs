using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BeachEquipmentStore.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
