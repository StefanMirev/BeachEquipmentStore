using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BeachEquipmentStore.Data;

namespace BeachEquipmentStore.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;


    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using static BeachEquipmentStore.Web.Infrastructure.Extensions.WebApplicationBuilderExtensions;
    using BeachEquipmentStore.Services.Data.Interfaces;
    using BeachEquipmentStore.Web.Infrastructure.ModelBinders;
    using Microsoft.AspNetCore.Mvc;

    using static BeachEquipmentStore.Common.GeneralApplicationConstants;
    using Microsoft.AspNetCore.Antiforgery;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<EquipmentStoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<EquipmentStoreDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            builder.Services.AddMemoryCache();
            builder.Services.AddRazorPages();
            builder.Services.AddApplicationServices(typeof(IProductService));

            builder.Services.AddAntiforgery(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost").AllowAnyMethod();
                });
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            })
                .AddCookie(options =>
                    {
                        options.Cookie.HttpOnly = true;
                        options.Cookie.Expiration = TimeSpan.FromDays(30);
                        options.SlidingExpiration = true;
                        options.Cookie.SameSite = SameSiteMode.None;
                        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                        options.LoginPath = "/Login";
                    });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAuthenticatedUser", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdministrator(AdminEmailAddress);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "admin",
                  pattern: "Admin");

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "Login",
                    defaults: new { area = "Identity", controller = "Account", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}",
                    defaults: new { area = "Admin" });
                    endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });



            app.Run();
        }
    }
}