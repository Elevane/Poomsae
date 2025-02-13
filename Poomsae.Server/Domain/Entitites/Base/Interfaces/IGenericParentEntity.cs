namespace Poomsae.Server.Domain.Entitites.Base.Interfaces
{
    public interface IGenericParentEntity<T> : IBaseEntity where T : class
    {
        public string Name { get; set; }

        public List<T> SubChildEntityList { get; set; }
    }
}