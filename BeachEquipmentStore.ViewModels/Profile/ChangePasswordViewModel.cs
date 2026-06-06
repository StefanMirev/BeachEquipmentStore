namespace BeachEquipmentStore.ViewModels.Profile
{
    using System.ComponentModel.DataAnnotations;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Сегашна парола")]
        public string CurrentPassword { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = PasswordMismatchError)]
        [Display(Name = "Потвърдете новата парола")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
