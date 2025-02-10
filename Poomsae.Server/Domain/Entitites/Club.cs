using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Club : GenericParentEntity<Sport>
    {
        public User Master { get; set; }
    }
}