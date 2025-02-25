using Poomsae.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Server.Domain.Entitites.Base.Interfaces
{
    public interface IBaseEntity : IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        int Likes { get; set; }
        string Name { get; set; }
    }
}