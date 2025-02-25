using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Domain.Entitites.Base.Interfaces;
using Poomsae.Infrastructure.Persistence;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Application.Services.Generics
{
    public class GenericService<T, R1, R2> : IGenericService<T, R1, R2> where T : class, IBaseEntity
          where R1 : class, IEntity
        where R2 : class, IBaseEntity
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GenericService(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<T>> Create(R1 request)
        {
            T? exist = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (exist == null)
                return Result<T>.Failure("create", "Could not create, because entity already exist.");
            T toCreate = _mapper.Map<T>(request);
            await _context.Set<T>().AddAsync(toCreate);
            await _context.SaveChangesAsync();
            return Result<T>.Success(exist);
        }

        public async Task<Result<T>> Delete(int id)
        {
            T? exist = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
                return Result<T>.Failure("delete", "Could not delete, because entity doesn't exist.");
            _context.Set<T>().Remove(exist);
            await _context.SaveChangesAsync();
            return Result<T>.Success(exist);
        }

        public async Task<Result<T>> Get(int id)
        {
            T? exist = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
                return Result<T>.Failure("get", "Could not get, because entity doesn't exist.");
            return Result<T>.Success(exist);
        }

        public async Task<Result<List<T>>> GetAll()
        {
            List<T> entitites = await _context.Set<T>().ToListAsync();
            return Result<List<T>>.Success(entitites);
        }

        public async Task<Result<T>> Update(R1 request)
        {
            T? exist = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (exist == null)
                return Result<T>.Failure("delete", "Could not delete, because entity doesn't exist.");
            T toUpdate = _mapper.Map<T>(request);
            _context.Set<T>().Entry(exist).CurrentValues.SetValues(toUpdate);
            await _context.SaveChangesAsync();
            return Result<T>.Success(exist);
        }
    }
}