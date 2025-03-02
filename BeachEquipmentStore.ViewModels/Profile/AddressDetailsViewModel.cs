namespace BeachEquipmentStore.Web.ViewModels.Profile
{
    public class AddressDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Town { get; set; } = null!;

        public int ZipCode { get; set; }

        public bool IsPrimaryAddress { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
