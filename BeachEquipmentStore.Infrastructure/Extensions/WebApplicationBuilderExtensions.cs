namespace BeachEquipmentStore.Infrastructure.Extensions
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;

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

            services.AddScoped<AllBusinessLogics>(sp => new AllBusinessLogics(sp.GetRequiredService<EquipmentStoreDbContext>()));
        }

        public static async Task<IApplicationBuilder> SeedAdministratorAsync(
            this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            if (!await roleManager.RoleExistsAsync(AdminRoleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole<Guid>(AdminRoleName));
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Failed to create role '{AdminRoleName}': " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            var adminUser = await userManager.FindByEmailAsync(email);
            if (adminUser == null)
            {
                return app;
            }

            if (!await userManager.IsInRoleAsync(adminUser, AdminRoleName))
            {
                var result = await userManager.AddToRoleAsync(adminUser, AdminRoleName);
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Failed to assign '{AdminRoleName}' to {email}: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            return app;
        }
    }
}
