using Poomsae.Server.Domain.Entities.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Step : GenericParentEntity<Movement>
    {
        public int Order { get; set; }
    }
}