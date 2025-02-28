using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Domain.Entitites.Base.Interfaces;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Application.Services.Generics.Interfaces
{
    public interface IGenericReferencesService<T, TRequest, TResponse> where T : class, IBaseEntity
        where TRequest : class, IEntity
        where TResponse : class, IBaseEntity
    {
        Task<Result> Create(TRequest request);

        Task<Result> Update(TRequest request);

        Task<Result> Delete(int id);

        Task<Result<TResponse>> Get(int id);

        Task<Result<List<TResponse>>> GetAll();
    }
}