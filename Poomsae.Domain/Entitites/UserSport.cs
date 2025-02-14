using Poomsae.Server.Domain.Entities.Base;

namespace Poomsae.Server.Domain.Entitites
{
    public class UserSport : AssociatedUserEntity
    {
        public Sport Sport { get; set; }

        private UserSport(User user, Sport sport)
        {
            Sport = sport;
            Follower = user;
            Validated = false;
        }

        public static UserSport Create(User user, Sport sport)
        {
            return new UserSport(user, sport);
        }
    }
}