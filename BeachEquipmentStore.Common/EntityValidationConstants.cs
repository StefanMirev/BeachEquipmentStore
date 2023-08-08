namespace BeachEquipmentStore.Common
{
    public static class EntityValidationConstants
    {
        public static class ApplicationUser
        {
            public const int FirstNameMaxLength = 50;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 50;
            public const int LastNameMinLength = 3;

            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 12;

            public const int TownNameMaxLength = 25;
            public const int TownNameMinLength = 4;

            public const int ZipCodeMaxValue= 9974;
            public const int ZipCodeMinValue = 1000;
        }

        public static class Category 
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 2;
        }


        public static class Product
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 7;

            public const int DescriptionMaxLength = 600;
            public const int DescriptionMinLength = 15;

            public const int ManufacturerNameMaxLength = 70;
            public const int ManufacturerNameMinLength = 5;

            public const int BarcodeMinValue = 5;
            public const int BarcodeMaxValue = 13;

            public const double PriceMinValue = 0.01;
            public const int PriceMaxValue = 250;
        }

        public static class Delivery
        {
            public const int TrackingNumberMaxLength = 40;
            public const int TrackingNumberMinLength = 8;

            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 12;

            public const int TownNameMaxLength = 25;
            public const int TownNameMinLength = 4;

            public const int ZipCodeMaxValue = 9974;
            public const int ZipCodeMinValue = 1000;
        }
    }
}
