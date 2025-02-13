using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Application.Models.Sports;
using Poomsae.Server.Application.Models.Sports.Requests;
using Poomsae.Server.Application.Models.UserSports.Requests;

namespace Poomsae.Server.Application.Services.UserSports.Interfaces
{
    public interface IUserSportsService
    {
        Task<Result> AddSport(AddUserSportsRequest request, int id);
    }
}