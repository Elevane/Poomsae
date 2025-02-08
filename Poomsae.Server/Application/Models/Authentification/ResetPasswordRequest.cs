using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poomsae.Server.Application.Models.Authentification
{
    public class ResetPasswordRequest
    {
        
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
