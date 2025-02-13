using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entities.Base
{
    public class GenericParentEntity<T> : BaseEntity, IGenericParentEntity<T> where T : class
    {
        public string Name { get; set; } = string.Empty;
        public List<T> SubChildEntityList { get; set; } = new();

        /// <summary>
        /// Créateur fonctionnel de l'entité, n'a aucun pouvoir sur l'entité autre que sur son
        /// existence sur le site.
        /// </summary>
        public User Creator { get; set; } = default!;

        public bool Validated { get; set; }
        public int Likes { get; set; }
    }

    public static class GenericParentEntityExtensions
    {
        public static void Initialize<T>(this IGenericParentEntity<T> entity, User creator, string name) where T : class
        {
            entity.Creator = creator;
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Name = name;
            entity.Validated = false;
            entity.Likes = 0;
            entity.SubChildEntityList = new List<T>();
        }
    }
}