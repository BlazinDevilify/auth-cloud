using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AuthCloud.Shared.Model;
using AuthCloud.Shared.Languages;
using AuthCloud.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AuthCloud.Shared.Authentication
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        public const string ClaimTypeApiKey = "es.soer.apikey";
        private IAuthService _auth;
        private IUserService _users;

        public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options, 
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IAuthService auth, IUserService users)
            : base(options, logger, encoder, clock)
        {
            _auth = auth;
            _users = users;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("ApiKey"))
            {
                return AuthenticateResult.NoResult();
            }

            Guid keyId = Guid.Parse(Request.Headers["ApiKey"]);

            Key key;
            User user;

            try
            {
                key = await _auth.AuthenticateByKey(keyId, Request.GetLanguage());
                user = await _users.GetUser(key.UserId, Request.GetLanguage());
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }

            return AuthenticateResult.Success(this.CreateTicket(key, user));
        }
    }
}
