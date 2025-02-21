using Poomsae.Server.Domain.Entities.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class UserSport : AssociatedUserEntity
    {
        public Sport Sport { get; set; }

        public static UserSport Create(User user, Sport sport)
        {
            return new UserSport()
            {
                Follower = user,
                Sport = sport,
                Validated = false
            };
        }
    }
}