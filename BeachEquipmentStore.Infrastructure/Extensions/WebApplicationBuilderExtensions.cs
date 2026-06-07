namespace BeachEquipmentStore.Infrastructure.Extensions
{
    using BeachEquipmentStore.Common.Enums;
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Common.Helpers;
    using BeachEquipmentStore.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class WebApplicationBuilderExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var entryAssembly = Assembly.GetEntryAssembly()
                ?? throw new InvalidOperationException("Could not determine entry assembly.");

            var assemblies = entryAssembly
                .GetReferencedAssemblies()
                .Where(a => a.Name!.StartsWith("BeachEquipmentStore"))
                .Select(Assembly.Load)
                .Append(entryAssembly);

            foreach (var assembly in assemblies)
            {
                var serviceTypes = assembly
                    .GetTypes()
                    .Where(t => t.Name.EndsWith("Service") && !t.IsInterface && !t.IsAbstract);

                foreach (var implementationType in serviceTypes)
                {
                    var interfaceType = implementationType.GetInterface($"I{implementationType.Name}");

                    if (interfaceType == null)
                    {
                        throw new InvalidOperationException(
                            $"No interface for the service {implementationType.Name} was found.");
                    }

                    services.AddScoped(interfaceType, implementationType);
                }
            }

            services.AddScoped<AllBusinessLogics>(sp =>
                new AllBusinessLogics(sp.GetRequiredService<EquipmentStoreDbContext>()));
        }

        public static async Task<IApplicationBuilder> SeedAdministratorAsync(
            this IApplicationBuilder app, string email, string? password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return app;

            using IServiceScope scope = app.ApplicationServices.CreateScope();
            var allBls = scope.ServiceProvider.GetRequiredService<AllBusinessLogics>();

            var existingUser = await allBls.UsersBL.AsQueryable()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (existingUser != null)
            {
                var adminAlreadyExists = await allBls.AdminUsersBL.AsQueryable()
                    .AnyAsync(a => a.Id == existingUser.Id);

                if (adminAlreadyExists) return app;

                var customerExists = await allBls.CustomerUsersBL.AsQueryable()
                    .AnyAsync(c => c.Id == existingUser.Id);

                if (customerExists) return app;
            }

            var adminRole = await allBls.UserRolesBL.AsQueryable()
                .FirstOrDefaultAsync(r => r.RoleType == UserType.Admin && r.IsActive);

            if (adminRole == null)
            {
                adminRole = new UserRole
                {
                    Name = "Administrator",
                    RoleType = UserType.Admin,
                    CanRead = true,
                    CanWrite = true,
                    CanDelete = true,
                    IsActive = true
                };
                await allBls.UserRolesBL.AddAsync(adminRole);
                await allBls.UserRolesBL.SaveChangesAsync();
            }

            if (existingUser == null)
            {
                existingUser = new User
                {
                    Email = email,
                    Username = email,
                    PasswordHash = PasswordHasher.HashPassword(password)
                };
                await allBls.UsersBL.AddAsync(existingUser);
                await allBls.UsersBL.SaveChangesAsync();
            }

            var adminUser = new AdminUser
            {
                Id = existingUser.Id,
                FirstName = "Admin",
                LastName = "User",
                IsActive = true,
                UserRoleId = adminRole.Id
            };

            await allBls.AdminUsersBL.AddAsync(adminUser);
            await allBls.AdminUsersBL.SaveChangesAsync();

            return app;
        }
    }
}
