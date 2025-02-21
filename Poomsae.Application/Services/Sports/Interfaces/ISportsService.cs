using Poomsae.Application.Models.Dtos.Sports;
using Poomsae.Application.Models.Dtos.Sports.Requests;
using Poomsae.Application.Models.Monads.Errors;

namespace Poomsae.Application.Services.Sports.Interfaces
{
    public interface ISportsService
    {
        Task<Result<List<SportResponse>>> GetSports(int userId);

        Task<Result<CreateSportRequest>> Create(CreateSportRequest request, int userId);

        Task<Result> AddSport(int sportId, int id);
    }
}