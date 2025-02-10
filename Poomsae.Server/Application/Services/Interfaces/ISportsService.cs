using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Application.Models.Sports;

namespace Poomsae.Server.Application.Services.Interfaces
{
    public interface ISportsService
    {
        Task<Result<List<SportResponse>>> GetSports(int userId);
    }
}