namespace AuthCloud.Shared.Languages
{
    public class LanguageEN : ILanguage
    {
        public string EmailAlreadyInUse() => "Email is already in use!";

        public string InvalidCredentials() => "Invalid Credentials. Please try again.";

        public string KeyExpired() => "Api key expired.";

        public string KeyNotFound() => "Api key not found.";

        public string NotImplemented() => "Functionality not implemented yet.";

        public string OldPasswordMismatch() => "The old password doesn't match.";

        public string UserEmailNotFound() => "Couldn't match email with any existing user.";

        public string UsernameAlreadyInUse() => "Username is already in use!";

        public string UsernameNotFound() => "Couldn't match username with any existing user.";

        public string UserNotFound() => "Couldn't find user.";
    }
}