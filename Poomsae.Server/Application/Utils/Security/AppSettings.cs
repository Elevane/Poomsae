namespace Poomsae.Server.Application.Utils.Security
{
    public class AppSettings
    {
        public string? SecretKey { get; set; }

        public string? Issuer { get; set; }

        public string? Audience { get; set; }

        public string? ApiKey { get; set; }

        public string? EncryptionKey { get; set; }
    }
}
