using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Domain.Entitites.Base.Interfaces;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Application.Services.Generics.Interfaces
{
    public interface IGenericService<T, R1, R2> where T : class, IBaseEntity
        where R1 : class, IEntity
        where R2 : class, IBaseEntity
    {
        Task<Result<T>> Create(R1 request);

        Task<Result<T>> Update(R1 request);

        Task<Result<T>> Delete(int id);

        Task<Result<T>> Get(int id);

        Task<Result<List<T>>> GetAll();
    }
}