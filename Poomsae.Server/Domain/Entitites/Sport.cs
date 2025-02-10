using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Sport : GenericParentEntity<Kata>
    {
        public string Ecole { get; set; }
    }
}