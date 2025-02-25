using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Step : BaseEntity
    {
        public int Order { get; set; }

        public List<Movement> Movements { get; set; }
    }
}