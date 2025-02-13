using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Server.Domain.Entitites.Base
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}