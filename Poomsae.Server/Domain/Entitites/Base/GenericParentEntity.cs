namespace Poomsae.Server.Domain.Entitites.Base
{
    public class GenericParentEntity<T> : BaseEntity where T : class
    {
        public string Name { get; set; }

        public List<T> SubChildEntityList { get; set; }

        /// <summary>
        /// Créateur fonctionnel de l'entitié, n'a aucun pouvoir sur l'entité autre que sur son
        /// existance sur le site.
        /// </summary>
        public User Creator { get; set; }

        public bool Validated
        { get { return Completion >= 100; } }

        public int Completion { get; set; }
    }
}