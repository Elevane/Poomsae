namespace Poomsae.Infrastructure.Externals.Mails.Interfaces
{
    public interface IMailSender
    {
        Task SendConfirmAsync(string email, string confirmToken);
    }
}