using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entities.Base
{
    public class AssociatedUserEntity : BaseEntity, IAssociatedUserEntity
    {
        public bool Validated { get; set; }
        public User Follower { get; set; }
    }
}