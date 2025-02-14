namespace Poomsae.Application.Services.External.Mails
{
    public interface IMailSender
    {
        Task SendConfirmAsync(string email, string confirmToken);
    }
}
