namespace BeachEquipmentStore.Infrastructure.Helpers
{
    using System.Globalization;

    public static class CultureConfig
    {
        public static void ConfigureCulture()
        {
            var culture = new CultureInfo("bg-BG")
            {
                DateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat
            };

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
