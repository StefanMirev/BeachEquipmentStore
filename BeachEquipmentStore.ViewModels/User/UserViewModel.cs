namespace BeachEquipmentStore.Web.ViewModels.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
