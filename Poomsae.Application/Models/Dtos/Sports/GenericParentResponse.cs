namespace Poomsae.Application.Models.Dtos.Sports
{
    public class GenericParentResponse<T> where T : class
    {
        public string Name { get; set; }

        public List<T> SubChildEntityList { get; set; }

        /// <summary>
        /// Créateur fonctionnel de l'entitié, n'a aucun pouvoir sur l'entité autre que sur son
        /// existance sur le site.
        /// </summary>
        public UserResponse Creator { get; set; }

        public bool Validated { get; set; }

        public int Likes { get; set; }
    }
}