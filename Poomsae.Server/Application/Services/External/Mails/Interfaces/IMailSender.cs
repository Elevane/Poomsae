namespace Poomsae.Server.Application.Services.External.Mails
{
    public interface IMailSender
    {
        Task SendConfirmAsync(string email, string confirmToken);
    }
}
