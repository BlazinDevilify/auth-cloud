using System;

namespace AuthCloud.Shared.Model
{
    public class User
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
    }
}
