namespace BeachEquipmentStore.Services
{
    using Core.Enums;
    using Core.Utilities;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using System.Text.RegularExpressions;
    using static Core.Common.Constants.GeneralApplicationConstants;
    using static Core.Common.Constants.Messages;

    public class AuthService : IAuthService
    {
        private readonly AllBusinessLogics _allBls;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(AllBusinessLogics allBls, IHttpContextAccessor httpContextAccessor)
        {
            _allBls = allBls;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> LoginAsync(string email, string password, bool rememberMe)
        {
            var user = await _allBls.UsersBL.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return false;

            var adminUser = await _allBls.AdminUsersBL.FindAsNoTrackingAsync(user.Id);

            if (adminUser != null)
            {
                if (!adminUser.IsActive || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
                    return false;

                var adminRole = adminUser.UserRoleId.HasValue
                    ? await _allBls.UserRolesBL.FindAsNoTrackingAsync(adminUser.UserRoleId.Value)
                    : null;

                await SignInAsync(BuildAdminClaims(user, adminUser, adminRole), rememberMe);
                return true;
            }

            var customerUser = await _allBls.CustomerUsersBL.FindAsync(user.Id);

            if (customerUser == null || !customerUser.IsActive)
                return false;

            if (customerUser.LockoutEnabled &&
                customerUser.LockoutEnd.HasValue &&
                customerUser.LockoutEnd.Value > DateTimeOffset.Now)
            {
                return false;
            }

            if (!PasswordHasher.VerifyPassword(password, user.PasswordHash))
            {
                if (customerUser.LockoutEnabled)
                {
                    customerUser.AccessFailedCount++;
                    if (customerUser.AccessFailedCount >= 5)
                        customerUser.LockoutEnd = DateTimeOffset.Now.AddMinutes(15);
                    await _allBls.CustomerUsersBL.SaveChangesAsync();
                }
                return false;
            }

            if (customerUser.AccessFailedCount > 0)
            {
                customerUser.AccessFailedCount = 0;
                customerUser.LockoutEnd = null;
                await _allBls.CustomerUsersBL.SaveChangesAsync();
            }

            var customerRole = customerUser.UserRoleId.HasValue
                ? await _allBls.UserRolesBL.FindAsNoTrackingAsync(customerUser.UserRoleId.Value)
                : null;

            await SignInAsync(BuildCustomerClaims(user, customerUser, customerRole), rememberMe);
            return true;
        }

        public async Task RegisterAsync(string firstName, string lastName, string email, string phone, string password)
        {
            if (!Regex.IsMatch(password, PasswordPattern))
                throw new ArgumentException(PasswordInvalid);

            var emailExists = await _allBls.UsersBL.All()
                .AnyAsync(u => u.Email == email);

            if (emailExists)
                throw new InvalidOperationException(UserEmailAlreadyExists);

            var defaultRole = await _allBls.UserRolesBL.FirstOrDefaultAsync(r => r.RoleType == UserType.Customer && r.IsActive);

            if (defaultRole == null)
            {
                defaultRole = new UserRole
                {
                    Name = "Customer",
                    RoleType = UserType.Customer,
                    IsActive = true
                };
                await _allBls.UserRolesBL.AddAsync(defaultRole);
                await _allBls.UserRolesBL.SaveChangesAsync();
            }

            var user = new User
            {
                Email = email,
                Username = email,
                PasswordHash = PasswordHasher.HashPassword(password)
            };

            var customerUser = new CustomerUser
            {
                Id = user.Id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phone,
                UserRoleId = defaultRole.Id,
                UserRole = defaultRole
            };

            using var transaction = _allBls.UsersBL.GetTransactionProxy();
            try
            {
                await _allBls.UsersBL.AddAsync(user);
                await _allBls.CustomerUsersBL.AddAsync(customerUser);
                await _allBls.UsersBL.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            await SignInAsync(BuildCustomerClaims(user, customerUser, defaultRole), false);
        }

        public async Task CreateAdminUserAsync(Guid userId, string firstName, string lastName)
        {
            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
                throw new InvalidOperationException(UserNotFound);

            if (await _allBls.CustomerUsersBL.All().AnyAsync(c => c.Id == userId))
                throw new InvalidOperationException(UserAlreadyCustomer);

            if (await _allBls.AdminUsersBL.All().AnyAsync(a => a.Id == userId))
                throw new InvalidOperationException(UserAlreadyAdmin);

            var adminRole = await _allBls.UserRolesBL.FirstOrDefaultAsync(r => r.RoleType == UserType.Admin && r.IsActive);

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
                await _allBls.UserRolesBL.AddAsync(adminRole);
                await _allBls.UserRolesBL.SaveChangesAsync();
            }

            var adminUser = new AdminUser
            {
                Id = userId,
                FirstName = firstName,
                LastName = lastName,
                IsActive = true,
                UserRoleId = adminRole.Id
            };

            await _allBls.AdminUsersBL.AddAsync(adminUser);
            await _allBls.AdminUsersBL.SaveChangesAsync();
        }

        public async Task LogoutAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext
                ?? throw new InvalidOperationException("No active HTTP context.");
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private static List<Claim> BuildAdminClaims(User user, AdminUser adminUser, UserRole? role)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.GivenName, adminUser.FirstName),
                new(ClaimTypes.Surname, adminUser.LastName),
                new("UserType", "Admin")
            };

            if (role != null)
            {
                claims.Add(new Claim("RoleName", role.Name));
                claims.Add(new Claim("CanRead", role.CanRead.ToString().ToLower()));
                claims.Add(new Claim("CanWrite", role.CanWrite.ToString().ToLower()));
                claims.Add(new Claim("CanDelete", role.CanDelete.ToString().ToLower()));
            }

            return claims;
        }

        private static List<Claim> BuildCustomerClaims(User user, CustomerUser customerUser, UserRole? role)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.GivenName, customerUser.FirstName),
                new(ClaimTypes.Surname, customerUser.LastName),
                new("UserType", "Customer")
            };

            if (role != null)
                claims.Add(new Claim("RoleName", role.Name));

            return claims;
        }

        private async Task SignInAsync(List<Claim> claims, bool rememberMe)
        {
            var httpContext = _httpContextAccessor.HttpContext
                ?? throw new InvalidOperationException("No active HTTP context.");

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddDays(30) : null
            };

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                authProperties);
        }
    }
}
