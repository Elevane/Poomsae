using Poomsae.Application.Models.Authentification;
using Poomsae.Application.Models.Errors;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Services.Authentification.Interfaces
{
    public interface IAuthService
    {
        Task<Result<RegisteredUser>> CreateUserAsync(RegisterUserRequest toRegister);

        Result<User> Get(string email);

        Task<Result<RegisteredUser>> AuthenticateUserAsync(AuthenticateUserRequest toAuthenticate);

        Task<Result> DeleteOrAnonymise(DeleteUserRequest request);

        Task<Result> ConfirmAccount(string token);
    }
}