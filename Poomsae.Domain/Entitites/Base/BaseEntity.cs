using Poomsae.Domain.Entitites.Base;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Server.Domain.Entitites.Base
{
    public class BaseEntity : Entity, IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public int Likes { get; set; }
    }

    public static class BaseEntityExtensions
    {
        public static void Initialize<T>(this IBaseEntity entity, User creator, string name) where T : class
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Name = name;
        }
    }
}