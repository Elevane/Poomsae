using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Application.Models.Sports;
using Poomsae.Server.Application.Services.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Infrastructure.Persistence;

namespace Poomsae.Server.Application.Services
{
    public class SportsService : ISportsService
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public SportsService(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<List<SportResponse>>> GetSports(int userId)
        {
            List<Sport> sports = await _context.Sports.Where(s => s.Creator.Id == userId).Include(s => s.SubChildEntityList).ThenInclude(s => s.SubChildEntityList).ThenInclude(s => s.SubChildEntityList).ToListAsync();
            List<SportResponse> responses = _mapper.Map<List<SportResponse>>(sports);
            return Result<List<SportResponse>>.Success(responses);
        }
    }
}