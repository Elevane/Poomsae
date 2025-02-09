namespace Poomsae.Server.Domain
{
    public class GenericParentEntity<T> where T  : class
    {
        public string Name { get; set; }

        public List<T> SubChildEntityList { get; set; }
    }
}
