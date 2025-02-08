using Poomsae.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poomsae.Server.Infrastructure.Persistence
{
    public interface IApplicationContext
    {
         DbSet<User> Users { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public int SaveChanges();
    }
}
