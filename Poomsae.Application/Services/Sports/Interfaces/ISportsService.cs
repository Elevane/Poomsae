using Poomsae.Application.Models.Errors;
using Poomsae.Application.Models.Sports;
using Poomsae.Application.Models.Sports.Requests;

namespace Poomsae.Application.Services.Sports.Interfaces
{
    public interface ISportsService
    {
        Task<Result<List<SportResponse>>> GetSports(int userId);

        Task<Result<CreateSportRequest>> Create(CreateSportRequest request, int userId);

        Task<Result> AddSport(int sportId, int id);
    }
}