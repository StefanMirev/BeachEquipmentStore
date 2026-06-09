namespace BeachEquipmentStore.ViewModels.Auth
{
    using System.ComponentModel.DataAnnotations;
    using static Core.Common.Constants.EntityValidationConstants.CustomerUser;
    using static Core.Common.Constants.GeneralApplicationConstants;
    using static Core.Common.Constants.Messages;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = FirstNameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FirstNameLengthError)]
        [Display(Name = "РРјРµ")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LastNameLengthError)]
        [Display(Name = "Р¤Р°РјРёР»РёСЏ")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = EmailRequired)]
        [EmailAddress(ErrorMessage = EmailInvalid)]
        [Display(Name = "РРјРµР№Р»")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = PhoneNumberRequired)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = PhoneNumberLengthError)]
        [Display(Name = "РўРµР»РµС„РѕРЅ")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = PasswordRequired)]
        [StringLength(128, MinimumLength = PasswordMinLength, ErrorMessage = PasswordLengthError)]
        [RegularExpression(PasswordPattern, ErrorMessage = PasswordInvalid)]
        [DataType(DataType.Password)]
        [Display(Name = "РџР°СЂРѕР»Р°")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = PasswordRequired)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = PasswordMismatchError)]
        [Display(Name = "РџРѕС‚РІСЉСЂРґРё РїР°СЂРѕР»Р°")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
