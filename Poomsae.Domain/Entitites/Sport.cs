using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Sport : BaseEntity
    {
        public string Ecole { get; set; }

        public List<Kata> Katas { get; set; }
    }
}