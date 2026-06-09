namespace BeachEquipmentStore.ViewModels.Auth
{
    using System.ComponentModel.DataAnnotations;
    using static Core.Common.Constants.Messages;

    public class LoginViewModel
    {
        [Required(ErrorMessage = EmailRequired)]
        [EmailAddress(ErrorMessage = EmailInvalid)]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = PasswordRequired)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [Display(Name = "Запомни ме")]
        public bool RememberMe { get; set; }
    }
}
