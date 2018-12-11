using System;
using System.Collections.Generic;
using System.Text;
using static AuthCloud.Shared.Constants;

namespace AuthCloud.Shared.Model
{
    public class Key
    {
        public enum Role : int
        {
            User = ROLE_USER,
            Admin = ROLE_ADMIN,
            Superadmin = ROLE_SUPERADMIN
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public DateTime? ValidThru { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
