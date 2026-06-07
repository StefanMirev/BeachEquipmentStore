namespace BeachEquipmentStore.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password, bool rememberMe);

        Task RegisterAsync(string firstName, string lastName, string email, string phone, string password);

        Task CreateAdminUserAsync(Guid userId, string firstName, string lastName);

        Task LogoutAsync();
    }
}
