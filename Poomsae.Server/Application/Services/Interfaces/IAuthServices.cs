using Poomsae.Server.Application.Models.Authentification;
using Poomsae.Server.Application.Models.Errors;

namespace Poomsae.Server.Application.Interfaces
{
    public interface IAuthService
    {

        Task<Result<RegisteredUser>> CreateUserAsync(RegisterUserRequest toRegister);
        Result<ApplicationUser> Get(string email);
        Task<Result<RegisteredUser>> AuthenticateUserAsync(AuthenticateUserRequest toAuthenticate);
        Task<Result> DeleteOrAnonymise(DeleteUserRequest request);
        Task<Result> ConfirmAccount(string token);
    }
}