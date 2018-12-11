namespace AuthCloud.Shared.Languages
{
    public class LanguageDE : ILanguage
    {
        public string EmailAlreadyInUse() => "Die Emailadresse ist bereits in Verwendung!";

        public string InvalidCredentials() => "Invalide Zugangsdaten. Bitte nochmals versuchen.";

        public string KeyExpired() => "Der API-Schlüssel ist abgelaufen.";

        public string KeyNotFound() => "Der API-Schlüssel wurde nicht gefunden.";

        public string NotImplemented() => "Diese Funktion ist noch nicht implementiert.";

        public string OldPasswordMismatch() => "Das alte Passwort stimmt nicht überein.";

        public string UserEmailNotFound() => "Die Emailadresse konnte keinem Benutzer zugeordnet werden.";

        public string UsernameAlreadyInUse() => "Die Benutzername ist bereits in Verwendung!";

        public string UsernameNotFound() => "Die Benutzername konnte keinem Benutzer zugeordnet werden.";

        public string UserNotFound() => "Der Benutzer konnte nicht gefunden werden.";
    }
}