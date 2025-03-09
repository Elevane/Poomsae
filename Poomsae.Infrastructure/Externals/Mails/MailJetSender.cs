using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Poomsae.Infrastructure.Externals.Mails.Interfaces;
using Poomsae.Infrastructure.Externals.Mails.Settings;

namespace Poomsae.Infrastructure.Externals.Mails
{
    public class MailJetSender : IMailSender
    {
        private readonly MailjetClient _client;
        private readonly MailJetSettings _settings;

        public MailJetSender(IOptions<MailJetSettings> settings)
        {
            _settings = settings.Value;
            _client = new MailjetClient(_settings.ApiKey, _settings.SecretKey);
        }

        public async Task SendConfirmAsync(string email, string token)
        {
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource
            };

            var mail = new TransactionalEmailBuilder()
                .WithFrom(new SendContact("poomsae.supp0rt@gmail.com"))
                .WithSubject("Confirma account")
                .WithHtmlPart($"<h1>Confirm your account</h1><p>Please click on the following link to activate your account : <a href='https://localhost:5173/confirm_password/{token}'>https://localhost:5173/confirm_password/{token}</a></p>")
                .WithTo(new SendContact(email))
                .Build();

            var response = await _client.SendTransactionalEmailAsync(mail);
        }

        public async Task SendResetPasswordAsync(string token, string email)
        {
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource
            };

            var mail = new TransactionalEmailBuilder()
                .WithFrom(new SendContact("poomsae.supp0rt@gmail.com"))
                .WithSubject("Reset your password")
            .WithHtmlPart($"<h1>Reset your password</h1><p>Please click on the following link to change your password : <a href='https://localhost:5173/confirm_password/{token}'>https://localhost:5173/confirm_password/{token}</a></p>")
            .WithTo(new SendContact(email))
            .Build();

            var response = await _client.SendTransactionalEmailAsync(mail);
        }
    }
}