using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class Movement : BaseEntity
    {
        public string BodyPart { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}