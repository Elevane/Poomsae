using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Step : GenericParentEntity<Movement>
    {
        public int Order { get; set; }
    }
}