using Poomsae.Application.Models.Errors;
using Poomsae.Application.Models.Sports;
using Poomsae.Application.Models.Sports.Requests;
using Poomsae.Application.Models.UserSports.Requests;

namespace Poomsae.Application.Services.UserSports.Interfaces
{
    public interface IUserSportsService
    {
        Task<Result> AddSport(AddUserSportsRequest request, int id);
    }
}