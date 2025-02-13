namespace Poomsae.Server.Domain.Entitites.Base
{
    public interface IGenericParentEntity<T> : IBaseEntity where T : class
    {
        public string Name { get; set; }

        public List<T> SubChildEntityList { get; set; }

        public User Creator { get; set; }

        public bool Validated { get; set; }

        public int Likes { get; set; }
    }
}