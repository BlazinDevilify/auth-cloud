namespace AuthCloud.Shared.Languages
{
    public interface ILanguage
    {
        string EmailAlreadyInUse();
        string UserNotFound();
        string UserEmailNotFound();
        string NotImplemented();
        string UsernameNotFound();
        string UsernameAlreadyInUse();
        string InvalidCredentials();
        string KeyExpired();
        string KeyNotFound();
        string OldPasswordMismatch();
    }
}
