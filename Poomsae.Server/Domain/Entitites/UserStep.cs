using Poomsae.Server.Domain.Entities.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class UserStep : AssociatedUserEntity
    {
        public Step Step { get; set; }
    }
}