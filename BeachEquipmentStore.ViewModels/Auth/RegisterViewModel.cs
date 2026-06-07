namespace BeachEquipmentStore.ViewModels.Auth
{
    using System.ComponentModel.DataAnnotations;
    using static BeachEquipmentStore.Common.Constants.EntityValidationConstants.CustomerUser;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = FirstNameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FirstNameLengthError)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LastNameLengthError)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = EmailRequired)]
        [EmailAddress(ErrorMessage = EmailInvalid)]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = PhoneNumberRequired)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = PhoneNumberLengthError)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = PasswordRequired)]
        [StringLength(128, MinimumLength = PasswordMinLength, ErrorMessage = PasswordLengthError)]
        [RegularExpression(PasswordPattern, ErrorMessage = PasswordInvalid)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = PasswordRequired)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = PasswordMismatchError)]
        [Display(Name = "Потвърди парола")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
