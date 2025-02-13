using Poomsae.Server.Domain.Entities.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class UserKata : AssociatedUserEntity
    {
        public Kata Katas { get; set; }
    }
}