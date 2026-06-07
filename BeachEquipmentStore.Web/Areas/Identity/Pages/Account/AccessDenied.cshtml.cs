namespace BeachEquipmentStore.Web.Areas.Identity.Pages.Account
{
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class AccessDeniedModel : PageModel
    {
        public string Reason { get; set; } = null!;

        public void OnGet()
        {
            Reason = HttpContext.Request.Query["reason"].ToString();

            if (string.IsNullOrEmpty(Reason))
            {
                Reason = "Нямате право да достъпите тази страница!";
            }
        }
    }
}
