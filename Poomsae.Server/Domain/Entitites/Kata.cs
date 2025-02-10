using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Kata : GenericParentEntity<Step>
    {
        public int Order { get; set; }
    }
}