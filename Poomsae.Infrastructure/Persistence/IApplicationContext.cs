﻿using Microsoft.EntityFrameworkCore;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Infrastructure.Persistence
{
    public interface IApplicationContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Sport> Sports { get; set; }
        DbSet<Kata> Katas { get; set; }
        DbSet<Step> Steps { get; set; }
        DbSet<Movement> Movements { get; set; }
        DbSet<Club> Clubs { get; set; }

        DbSet<UserSport> UserSports { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public int SaveChanges();
    }
}