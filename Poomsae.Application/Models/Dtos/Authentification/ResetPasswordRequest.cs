namespace Poomsae.Application.Models.Dtos.Authentification
{
    public class ResetPasswordRequest
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}