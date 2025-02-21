using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Poomsae.Application.Models.Dtos.UserSports.Requests;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.UserSports.Interfaces;
using Poomsae.Infrastructure.Persistence;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Services.UserSports
{
    public class UserSportsService : IUserSportsService
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly User _authenticatedUser;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserSportsService(IApplicationContext context, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _authenticatedUser = _contextAccessor?.HttpContext?.Items["User"] as User;
        }

        public async Task<Result> AddSport(AddUserSportsRequest sport, int userId)
        {
            Sport exist = await _context.Sports.FirstAsync(s => s.Id == sport.SportsId);
            if (exist == null)
                return Result.Failure("metier", "Le sport à ajouter n'existe pas");
            UserSport userSport = UserSport.Create(_authenticatedUser, exist);
            _authenticatedUser.Sports.Add(userSport);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result<List<UserSport>>> GetAll(int userId)
        {
            List<UserSport> userSports = await _context.UserSports.Where(us => us.Follower.Id == userId).ToListAsync();
            return Result<List<UserSport>>.Success(userSports);
        }
    }
}