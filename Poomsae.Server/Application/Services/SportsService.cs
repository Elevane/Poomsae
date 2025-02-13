using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Poomsae.Server.Application.Models.Authentification;
using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Application.Models.Sports;
using Poomsae.Server.Application.Models.Sports.Requests;
using Poomsae.Server.Application.Services.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Infrastructure.Persistence;

namespace Poomsae.Server.Application.Services
{
    public class SportsService : ISportsService
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly User _authenticatedUser;
        private readonly IHttpContextAccessor _contextAccessor;

        public SportsService(IApplicationContext context, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _authenticatedUser = _contextAccessor?.HttpContext?.Items["User"] as User;
        }

        public async Task<Result<CreateSportRequest>> Create(CreateSportRequest request, int userId)
        {
            Sport exist = await _context.Sports.FirstAsync(s => s.Name.ToLower() == request.Name.ToLower() && s.Creator.Id == userId);
            if (exist != null)
                return Result<CreateSportRequest>.Failure("creation", "Un sport existe déjà avec le même nom pour cet utilisateur");
            Sport toCreate = Sport.Create(_authenticatedUser, request.Name, request.Ecole);
            await _context.Sports.AddAsync(toCreate);
            await _context.SaveChangesAsync();
            return Result<CreateSportRequest>.Success(request);
        }

        public async Task<Result<List<SportResponse>>> GetSports(int userId)
        {
            List<Sport> sports = await _context.Sports.Where(s => s.Creator.Id == userId).Include(s => s.SubChildEntityList).ThenInclude(s => s.SubChildEntityList).ThenInclude(s => s.SubChildEntityList).ToListAsync();
            List<SportResponse> responses = _mapper.Map<List<SportResponse>>(sports);
            return Result<List<SportResponse>>.Success(responses);
        }
    }
}