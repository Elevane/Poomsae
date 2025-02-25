using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Kata : BaseEntity
    {
        public int Order { get; set; }

        public List<Step> Steps { get; set; }
    }
}