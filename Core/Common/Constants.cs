namespace Core.Common
{
    public static class Constants
    {
        public static class GeneralApplicationConstants
        {
            public const int DefaultPage = 1;
            public const int EntitiesPerPage = 9;

            public const decimal DeliveryPrice = 5.50m;

            public const string AdminAreaName = "Admin";

            public const int PasswordMinLength = 10;
            public const string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{10,}$";
        }

        public static class EntityValidationConstants
        {
            public static class User
            {
                public const int EmailMaxLength = 256;
                public const int EmailMinLength = 5;

                public const int UsernameMaxLength = 256;
                public const int UsernameMinLength = 3;
            }

            public static class CustomerUser
            {
                public const int FirstNameMaxLength = 50;
                public const int FirstNameMinLength = 2;

                public const int LastNameMaxLength = 50;
                public const int LastNameMinLength = 3;

                public const int PhoneNumberMaxLength = 15;
                public const int PhoneNumberMinLength = 7;
            }

            public static class AdminUser
            {
                public const int FirstNameMaxLength = 50;
                public const int FirstNameMinLength = 2;

                public const int LastNameMaxLength = 50;
                public const int LastNameMinLength = 3;
            }

            public static class UserRole
            {
                public const int NameMaxLength = 50;
                public const int NameMinLength = 3;

                public const int DescriptionMaxLength = 200;
            }

            public static class Address
            {
                public const int AddressMaxLength = 100;
                public const int AddressMinLength = 12;

                public const int TownNameMaxLength = 25;
                public const int TownNameMinLength = 4;

                public const int ZipCodeMaxLength = 10;
                public const int ZipCodeMinLength = 3;
            }

            public static class ApplicationUser
            {
                public const int FirstNameMaxLength = 50;
                public const int FirstNameMinLength = 2;

                public const int LastNameMaxLength = 50;
                public const int LastNameMinLength = 3;
            }

            public static class Category
            {
                public const int NameMaxLength = 30;
                public const int NameMinLength = 2;
            }

            public static class Manufacturer
            {
                public const int NameMaxLength = 70;
                public const int NameMinLength = 5;
            }

            public static class Product
            {
                public const int NameMaxLength = 100;
                public const int NameMinLength = 7;

                public const int DescriptionMaxLength = 600;
                public const int DescriptionMinLength = 15;

                public const long BarcodeMinLength = 10000;
                public const long BarcodeMaxLength = 9999999999999;

                public const string PriceMinValue = "0.01";
                public const string PriceMaxValue = "250";
            }
        }

        public static class Messages
        {
            //Address
            public const string AddressNotFound = "Адресът не съществува!";
            public const string AddressLimitReached = "Максималният позволен брой адреси е 10. За да добавите друг, моля първо изтрийте един от съществуващите!";
            public const string AddressAddSuccess = "Адресът бе успешно добавен.";
            public const string AddressUpdateSuccess = "Промените ви по адреса са запазени.";
            public const string AddressZipCodeInvalid = "Моля въведете валиден пощенски код!";

            //Cart
            public const string CartAddSuccess = "Продуктът бе успешно добавен.";
            public const string CartClearSuccess = "Kоличката бе почистена.";
            public const string CartRemoveSuccess = "Избраният артикул бе премахнат от количката.";

            //Category
            public const string CategoriesNotFound = "Няма обособени категории!";

            //Manufacturer
            public const string ManufacturersNotFound = "Няма обособени производители!";

            //Order
            public const string OrderNotFound = "Такава поръчка не съществува!";
            public const string OrderCreateSuccess = "Вашата поръчка бе успешно създадена.";
            public const string OrderDeliverySuccess = "Поръчката е отбелязана като доставена.";
            public const string OrderDeliveryFailure = "Поръчката не можа да бъде доставена.";

            //Product
            public const string ProductNotFound = "Продуктът не съществува!";
            public const string ProductOutOfStock = "Недостатъчна наличност!";
            public const string ProductQuantityTooLow = "Трябва да добавите поне една бройка от дадения продукт!";
            public const string ProductRestockSuccess = "Успешно увеличихте наличието на продукта/ите.";

            //Registration
            public const string FirstNameRequired = "Полето за име е задължително!";
            public const string FirstNameLengthError = "{0} трябва да бъде поне {2} и не повече от {1} символа!";
            public const string LastNameRequired = "Полето за фамилия е задължително!";
            public const string LastNameLengthError = "{0} трябва да бъде поне {2} и не повече от {1} символа!";
            public const string EmailRequired = "Полето за електронна поща е задължително!";
            public const string EmailInvalid = "Моля въведете валиден адрес на електронна поща!";
            public const string PhoneNumberRequired = "Полето за телефонен номер е задължително!";
            public const string PhoneNumberLengthError = "Телефонният номер трябва да съдържа поне {2} и не повече от {1} символа.";
            public const string PasswordRequired = "Полето за парола е задължително!";
            public const string PasswordInvalid = "Паролата трябва да съдържа поне една главна буква, една малка буква, една цифра и един специален символ.";
            public const string PasswordMismatchError = "Полетата за парола трябва да съответстват!";
            public const string PasswordLengthError = "{0} трябва да бъде поне {2} и не повече от {1} символа!";

            //User
            public const string UserNotFound = "Потребителят не съществува!";
            public const string UserDetailsUpdateSuccess = "Промените по профила ви бяха успешно запазени.";
            public const string UserIncorrectPassword = "Въведената парола не е вярна!";
            public const string UserPasswordChangeSuccess = "Успешно променихте паролата си.";
            public const string UserAdminGrantSuccess = "Потребителят е направен администратор.";
            public const string UserAdminGrantFailure = "Възникна грешка при опита потребителя да бъде направен администратор!";
            public const string UserEmailAlreadyExists = "Вече съществува акаунт с този имейл адрес!";
            public const string UserAlreadyCustomer = "Потребителят е клиент и не може да бъде направен администратор!";
            public const string UserAlreadyAdmin = "Потребителят вече е администратор!";
            public const string UserLockedOut = "Акаунтът ви е заключен. Моля, опитайте по-късно.";
            public const string UserInvalidCredentials = "Невалиден имейл или парола!";
        }
    }
}
