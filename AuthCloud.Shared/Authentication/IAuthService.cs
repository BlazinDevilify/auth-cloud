using AuthCloud.Shared.Languages;
using AuthCloud.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCloud.Shared.Authentication
{
    public interface IAuthService
    {
        Task<Key> AuthenticateByUsername(string username, string password, ILanguage language);

        Task<Key> AuthenticateByEmail(string email, string password, ILanguage language);

        Task<Key> AuthenticateByKey(Guid keyId, ILanguage language);

        Task<Key> GetKey(Guid keyId, ILanguage language);

        Task DisposeKey(Guid keyId);
    }
}
