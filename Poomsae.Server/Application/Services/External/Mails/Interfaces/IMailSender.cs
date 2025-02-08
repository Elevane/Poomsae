using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poomsae.Server.Application.Services.External.Mails
{
    public interface IMailSender
    {
        Task SendConfirmAsync(string email, string confirmToken);
    }
}
