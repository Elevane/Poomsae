using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Club : BaseEntity
    {
        public string Name { get; set; }
        public User? Master { get; set; }
        public List<User> Students { get; set; } = new List<User>();

        public List<Sport> Sports { get; set; } = new List<Sport>();
    }
}