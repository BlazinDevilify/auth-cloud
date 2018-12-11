using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AuthCloud.Shared.Languages;
using AuthCloud.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AuthCloud.Shared.Model;

namespace AuthCloud.Shared.Authentication
{
    public class UserCredentialsAuthenticationHandler : AuthenticationHandler<UserCredentialsAuthenticationOptions>
    {
        private IAuthService _auth;
        private IUserService _users;

        public UserCredentialsAuthenticationHandler(IOptionsMonitor<UserCredentialsAuthenticationOptions> options, 
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IAuthService auth, IUserService users)
            : base(options, logger, encoder, clock)
        {
            _auth = auth;
            _users = users;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }

            string[] credentials = ((string)Request.Headers["Authorization"]).Split(":");
            string email = credentials[0]; //TODO: later check if email or username
            string password = credentials[1];

            Key key;
            User user;
            try
            {
                key = await _auth.AuthenticateByEmail(email, password, Request.GetLanguage());
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
