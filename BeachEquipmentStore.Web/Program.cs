namespace BeachEquipmentStore.Web
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Infrastructure.Extensions;
    using BeachEquipmentStore.Infrastructure.Helpers;
    using BeachEquipmentStore.Infrastructure.ModelBinders;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using OwaspHeaders.Core.Extensions;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;
    using static BeachEquipmentStore.Infrastructure.Extensions.WebApplicationBuilderExtensions;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<EquipmentStoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = PasswordMinLength;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<EquipmentStoreDbContext>()
                .AddDefaultTokenProviders();

            var mvcBuilder = builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/AccessDenied";
            });

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            if (builder.Environment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
                builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            }
            else
            {
                builder.Services.AddRazorPages();
            }
            builder.Services.AddApplicationServices();

            CultureConfig.ConfigureCulture();

            builder.Services.AddAntiforgery(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAuthenticatedUser", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });

            var app = builder.Build();

            await app.SeedAdministratorAsync(builder.Configuration["AdminEmail"]!);

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHsts();

            app.UseSecureHeadersMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                    ctx.Context.Response.Headers["Cache-Control"] = "public, max-age=31536000, immutable"
            });

            app.UseStatusCodePages();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    if (!context.Request.Path.StartsWithSegments("/lib") &&
                        !context.Request.Path.StartsWithSegments("/css") &&
                        !context.Request.Path.StartsWithSegments("/js") &&
                        !context.Request.Path.StartsWithSegments("/images"))
                    {
                        context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                        context.Response.Headers["Pragma"] = "no-cache";
                        context.Response.Headers["Expires"] = "0";
                    }
                    return Task.CompletedTask;
                });
                await next();
            });


            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Register",
                pattern: "/Register",
                defaults: new { area = "Identity", page = "/Account/Register" });

            app.MapControllerRoute(
                name: "Login",
                pattern: "/Login",
                defaults: new { area = "Identity", page = "/Account/Login" });

            app.MapControllerRoute(
                name: "AccessDenied",
                pattern: "/AccessDenied",
                defaults: new { area = "Identity", page = "/Account/AccessDenied" });

            app.MapControllerRoute(
                name: "areaRoute",
                pattern: "{area:exists}/{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });

            app.MapRazorPages();

            app.Run();
        }
    }
}