using Poomsae.Application.Models.Dtos.UserSports.Requests;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Services.UserSports.Interfaces
{
    public interface IUserSportsService
    {
        Task<Result> AddSport(AddUserSportsRequest request, int id);

        Task<Result<List<UserSport>>> GetAll(int userId);
    }
}