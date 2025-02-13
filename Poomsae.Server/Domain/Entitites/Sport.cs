using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Sport : GenericParentEntity<Kata>
    {
        public string Ecole { get; set; }

        internal static Sport Create(User creator, string name, string ecole)
        {
            Sport sport = new Sport();
            sport.Initialize(creator, name);
            sport.Ecole = ecole;
            return sport;
        }
    }
}