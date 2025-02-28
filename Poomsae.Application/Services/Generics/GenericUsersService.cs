using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Domain.Entitites.Base;
using Poomsae.Domain.Entitites.Base.Interfaces;
using Poomsae.Infrastructure.Persistence;
using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Application.Services.Generics
{
    public class GenericUsersService<T, TRequest, TResponse> : IGenericUsersService<T, TRequest, TResponse> where T : class, IAssociatedUserEntity
          where TRequest : class, IEntity
        where TResponse : class, IBaseEntity
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GenericUsersService(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Create(TRequest request, int userId)
        {
            T? exist = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == request.Id && x.Follower.Id == userId);
            if (exist == null)
                return Result<TResponse>.Failure("create", $"Could not create {typeof(T).Name}, because entity already exist.");
            T toCreate = _mapper.Map<T>(request);
            await _context.Set<T>().AddAsync(toCreate);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> Delete(int id, int userId)
        {
            T? exist = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id && x.Follower.Id == userId);
            if (exist == null)
                return Result<TResponse>.Failure("delete", $"Could not delete {typeof(T).Name}, because entity doesn't exist.");
            _context.Set<T>().Remove(exist);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result<TResponse>> Get(int id)
        {
            T? exist = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
                return Result<TResponse>.Failure("get", $"Could not get {typeof(T).Name}, because entity doesn't exist.");
            TResponse response = _mapper.Map<TResponse>(exist);
            return Result<TResponse>.Success(response);
        }

        public async Task<Result<List<TResponse>>> GetAll(int userId)
        {
            List<T> entitites = await _context.Set<T>().Where(x => x.Follower.Id == userId).ToListAsync();
            List<TResponse> responses = _mapper.Map<List<TResponse>>(entitites);
            return Result<List<TResponse>>.Success(responses);
        }

        public async Task<Result> Update(TRequest request, int userId)
        {
            T? exist = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == request.Id && x.Follower.Id == userId);
            if (exist == null)
                return Result<TResponse>.Failure("delete", $"Could not delete {typeof(T).Name}, because entity doesn't exist.");
            _mapper.Map(request, exist);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}