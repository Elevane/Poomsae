namespace Poomsae.Server.Domain
{
    public class Step : GenericParentEntity<Movement>
    {
        public int Order { get; set; }
    }
}