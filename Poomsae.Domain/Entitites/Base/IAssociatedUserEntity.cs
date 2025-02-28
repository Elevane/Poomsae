using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Server.Domain.Entities.Base
{
    public interface IAssociatedUserEntity : IBaseEntity
    {
        bool Validated { get; set; }
        User Follower { get; set; }
    }
}