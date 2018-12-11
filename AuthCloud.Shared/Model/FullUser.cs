using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCloud.Shared.Model
{
    public class FullUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime JoinedOn { get; set; }

        public DateTime? ConfirmedOn { get; set; }

        public string Password { get; set; } //TODO: Later bcrypt hash
    }
}
