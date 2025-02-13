using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Domain.Entitites.Base;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Server.Domain.Entities.Base
{
    public class GenericParentEntity<T> : BaseEntity, IGenericParentEntity<T> where T : class
    {
        public string Name { get; set; } = string.Empty;
        public int Likes { get; set; }
        public List<T> SubChildEntityList { get; set; } = new();
    }

    public static class GenericParentEntityExtensions
    {
        public static void Initialize<T>(this IGenericParentEntity<T> entity, User creator, string name) where T : class
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Name = name;
            entity.SubChildEntityList = new List<T>();
        }
    }
}