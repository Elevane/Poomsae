using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Domain.Entitites.Base.Interfaces;
using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Application.Services.Generics.Interfaces
{
    public interface IGenericUsersService<T, TRequest, TResponse> where T : class, IAssociatedUserEntity
        where TRequest : class, IEntity
        where TResponse : class, IBaseEntity
    {
        Task<Result> Create(TRequest request, int userId);

        Task<Result> Update(TRequest request, int userId);

        Task<Result> Delete(int id, int userId);

        Task<Result<TResponse>> Get(int id);

        Task<Result<List<TResponse>>> GetAll(int userId);
    }
}