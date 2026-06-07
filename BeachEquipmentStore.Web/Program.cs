namespace BeachEquipmentStore.Web
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Infrastructure.Extensions;
    using BeachEquipmentStore.Infrastructure.Helpers;
    using BeachEquipmentStore.Infrastructure.ModelBinders;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OwaspHeaders.Core.Extensions;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<EquipmentStoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                    options.SlidingExpiration = true;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/AccessDenied";
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAuthenticatedUser", policy => policy.RequireAuthenticatedUser());
                options.AddPolicy("AdminArea", policy => policy.RequireClaim("UserType", "Admin"));
                options.AddPolicy("AdminWrite", policy =>
                {
                    policy.RequireClaim("UserType", "Admin");
                    policy.RequireClaim("CanWrite", "true");
                });
                options.AddPolicy("AdminDelete", policy =>
                {
                    policy.RequireClaim("UserType", "Admin");
                    policy.RequireClaim("CanDelete", "true");
                });
            });

            var mvcBuilder = builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            if (builder.Environment.IsDevelopment())
                mvcBuilder.AddRazorRuntimeCompilation();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddApplicationServices();

            CultureConfig.ConfigureCulture();

            builder.Services.AddAntiforgery(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            var app = builder.Build();

            await app.SeedAdministratorAsync(builder.Configuration["AdminEmail"]!, builder.Configuration["AdminPassword"]);

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHsts();

            app.UseSecureHeadersMiddleware();
            app.Use(async (context, next) =>
            {
                context.Response.Headers["Cross-Origin-Embedder-Policy"] = "unsafe-none";
                await next(context);
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                    ctx.Context.Response.Headers["Cache-Control"] = "public, max-age=31536000, immutable"
            });

            app.UseStatusCodePagesWithReExecute("/NotFound");

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
                name: "areaRoute",
                pattern: "{area:exists}/{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });

            app.Run();
        }
    }
}
