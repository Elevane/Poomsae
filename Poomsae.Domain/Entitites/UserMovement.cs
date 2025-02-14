using Poomsae.Server.Domain.Entities.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class UserMovement : AssociatedUserEntity
    {
        public Movement Movement { get; set; }
    }
}