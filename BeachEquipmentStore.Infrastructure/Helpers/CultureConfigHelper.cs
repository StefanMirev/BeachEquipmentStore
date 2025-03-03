namespace BeachEquipmentStore.Infrastructure.Helpers
{
    using System.Globalization;

    public static class CultureConfig
    {
        public static void ConfigureCulture()
        {
            CultureInfo invariantCulture = CultureInfo.InvariantCulture;

            CultureInfo customCulture = (CultureInfo)new CultureInfo("bg-BG").Clone();

            customCulture.NumberFormat.CurrencySymbol = new CultureInfo("bg-BG").NumberFormat.CurrencySymbol;
            customCulture.NumberFormat.CurrencyDecimalSeparator = new CultureInfo("bg-BG").NumberFormat.CurrencyDecimalSeparator;
            customCulture.NumberFormat.CurrencyGroupSeparator = new CultureInfo("bg-BG").NumberFormat.CurrencyGroupSeparator;
            customCulture.NumberFormat.CurrencyGroupSizes = new CultureInfo("bg-BG").NumberFormat.CurrencyGroupSizes;

            customCulture.DateTimeFormat = invariantCulture.DateTimeFormat;

            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;
        }
    }
}
