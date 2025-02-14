using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Poomsae.Application.Utils.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Poomsae.Application.Services.Helpers
{
    public class SecurityHelpers
    {
        private readonly AppSettings _appSettings;

        public SecurityHelpers(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            if (_appSettings == null || _appSettings.SecretKey == null || _appSettings.Issuer == null || _appSettings.Audience == null || _appSettings.EncryptionKey == null) throw new NullReferenceException("Secret keys should not be null while activating userService");
        }

        public string? generateJwtToken(string email)
        {
            try
            {
                if (_appSettings.SecretKey == null) return null;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("email", email) }),
                    Expires = DateTime.UtcNow.AddMinutes(65),
                    Issuer = _appSettings.Issuer,
                    Audience = _appSettings.Audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch
            {
                return null;
            }
        }

        public string GetHash(string input)
        {
            SHA256 hashAlgorithm = SHA256.Create();
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public JwtSecurityToken? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (_appSettings.SecretKey == null) throw new NullReferenceException($"Secret settings were not set correctly while using {typeof(SecurityHelpers)}");
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = true,
                    ValidIssuer = _appSettings.Issuer,
                    ValidAudience = _appSettings.Audience,
                    ValidateIssuer = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch
            {
                return null;
            }
        }

        public string? Encrypt(string toEncryptMessage)
        {
            try
            {
                System.Security.Cryptography.Aes aes = CreateEncryption();
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                MemoryStream memoryStream = new MemoryStream();
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(toEncryptMessage);
                    }
                }
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch
            {
                return null;
            }
        }

        private System.Security.Cryptography.Aes CreateEncryption()
        {
            SHA256 sha256 = SHA256.Create();
            System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create();
            if (_appSettings == null || _appSettings.EncryptionKey == null || _appSettings.SecretKey == null)
                throw new NullReferenceException("Appsetings EncryptionKey or secretKey is not corectly set");
            byte[] keyBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_appSettings.EncryptionKey));
            byte[] ivBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_appSettings.SecretKey));
            byte[] key = keyBytes.Take(32).ToArray(); // 256 bits
            byte[] iv = ivBytes.Take(16).ToArray(); // 128 bits
            aes.Key = key;
            aes.IV = iv;
            return aes;
        }

        public string? Decrypt(string cryptedMessage)
        {
            try
            {
                System.Security.Cryptography.Aes aes = CreateEncryption();

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using var memoryStream = new MemoryStream(Convert.FromBase64String(cryptedMessage));
                using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                using var streamReader = new StreamReader(cryptoStream);

                return streamReader.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        internal string? generateConfirmToken(string email)
        {
            try
            {
                if (_appSettings.SecretKey == null) return null;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("email", email) }),
                    Expires = DateTime.UtcNow.AddDays(5),
                    Issuer = _appSettings.Issuer,
                    Audience = _appSettings.Audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch
            {
                return null;
            }
        }
    }
}