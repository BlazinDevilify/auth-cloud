using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using AuthCloud.Shared.Languages;
using AuthCloud.Shared.Users;
using AuthCloud.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthCloud.Shared.Authentication
{
    public static class Extensions
    {
        public const string ClaimTypeApiKey = "es.soer.apikey";

        public static async Task<Key> GetKeyAsync(this Controller controller, IAuthService auth)
        {
            IEnumerable<Claim> claims = controller.User.Claims;
            Claim apiKeyClaim = claims.FirstOrDefault(x => x.Type == ApiKeyAuthenticationHandler.ClaimTypeApiKey);

            if (apiKeyClaim == null)
            {
                return null;
            }

            Key key = await auth.GetKey(Guid.Parse(apiKeyClaim.Value), controller.GetLanguage());
            return key;
        }

        public static async Task<User> GetUserAsync(this Controller controller, IUserService users)//TODO: Move
        {
            IEnumerable<Claim> claims = controller.User.Claims;
            Claim emailClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email); //TODO: maybe not get user by email

            if (emailClaim == null)
            {
                return null;
            }

            User user = await users.GetUserByEmail(emailClaim.Value, controller.GetLanguage());
            return user;
        }

        public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder, Action<ApiKeyAuthenticationOptions> configureOptions)
        {
            return builder.AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKey", configureOptions);
        }

        public static AuthenticationBuilder AddUserCredentials(this AuthenticationBuilder builder, Action<UserCredentialsAuthenticationOptions> configureOptions)
        {
            return builder.AddScheme<UserCredentialsAuthenticationOptions, UserCredentialsAuthenticationHandler>("UserCredentials", configureOptions);
        }

        public static AuthenticationTicket CreateTicket<T>(this AuthenticationHandler<T> handler, Key key, User user) where T : AuthenticationSchemeOptions, new()
        {
            List<Claim> claims = new List<Claim>() //TODO: Real shit
            {
                new Claim(ClaimTypes.NameIdentifier, key.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypeApiKey, key.Id.ToString())
            };

            foreach (Key.Role role in key.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString("g")));
            }

            ClaimsIdentity identity = new ClaimsIdentity(claims, handler.Scheme.Name);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, handler.Scheme.Name);
            return ticket;
        }
        
        public static IServiceCollection AddAuthService<T>(this IServiceCollection service) where T : class, IAuthService
        {
            return service.AddTransient<IAuthService, T>();
        }
    }
}
