﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Poomsae.Application.Models.Dtos.Sports;
using Poomsae.Application.Models.Dtos.Sports.Requests;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.Sports.Interfaces;
using Poomsae.Infrastructure.Persistence;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Services
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

        public async Task<Result> AddSport(int sportId, int userId)
        {
            Sport exist = await _context.Sports.FirstAsync(s => s.Id == sportId);
            if (exist == null)
                return Result.Failure("metier", "Le sport à ajouter n'existe pas");
            UserSport userSport = UserSport.Create(_authenticatedUser, exist);
            _authenticatedUser.Sports.Add(userSport);
            await _context.SaveChangesAsync();
            return Result<Result>.Success();
        }

        public async Task<Result<CreateSportRequest>> Create(CreateSportRequest request, int userId)
        {
            Sport exist = await _context.Sports.FirstAsync(s => s.Name.ToLower() == request.Name.ToLower());
            if (exist != null)
                return Result<CreateSportRequest>.Failure("creation", "Un sport existe déjà avec le même nom pour cet utilisateur");
            Sport toCreate = Sport.Create(_authenticatedUser, request.Name, request.Ecole);
            await _context.Sports.AddAsync(toCreate);
            await _context.SaveChangesAsync();
            return Result<CreateSportRequest>.Success(request);
        }

        public async Task<Result<List<SportResponse>>> GetSports(int userId)
        {
            List<Sport> sports = await _context.Sports.Include(s => s.SubChildEntityList).ThenInclude(s => s.SubChildEntityList).ThenInclude(s => s.SubChildEntityList).ToListAsync();
            List<SportResponse> responses = _mapper.Map<List<SportResponse>>(sports);
            return Result<List<SportResponse>>.Success(responses);
        }
    }
}