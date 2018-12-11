using AuthCloud.Shared.Languages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthCloud.Shared.Model;

namespace AuthCloud.Shared.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(ILanguage language);

        Task<User> GetUser(Guid id, ILanguage language);

        Task<User> GetUserByEmail(string email, ILanguage language);

        Task<User> GetUserByUsername(string username, ILanguage language);

        Task ModifyUser(User user, ILanguage language);

        Task CreateUser(User user, string password, ILanguage language);

        Task DeleteUser(Guid id, ILanguage language);

        Task ChangePassword(Guid userId, string newPassword, ILanguage language);

        Task ChangePassword(Guid userId, string newPassword, string oldPassword, ILanguage language);

        Task<IEnumerable<Key.Role>> GetRoles(Guid userId, ILanguage language);

        Task AddRole(Guid userId, Key.Role role, ILanguage language);
    }
}