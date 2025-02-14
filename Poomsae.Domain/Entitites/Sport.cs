using Poomsae.Server.Domain.Entities.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Sport : GenericParentEntity<Kata>
    {
        public string Ecole { get; set; }

        public static Sport Create(User creator, string name, string ecole)
        {
            Sport sport = new Sport();
            sport.Initialize(creator, name);
            sport.Ecole = ecole;
            return sport;
        }
    }
}