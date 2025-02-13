using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Application.Models.Sports;
using Poomsae.Server.Application.Models.Sports.Requests;

namespace Poomsae.Server.Application.Services.Interfaces
{
    public interface ISportsService
    {
        Task<Result<List<SportResponse>>> GetSports(int userId);

        Task<Result<CreateSportRequest>> Create(CreateSportRequest request, int userId);
    }
}