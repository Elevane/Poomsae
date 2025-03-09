using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Dtos.Users.Requests
{
    public class UserSportRequest : AssociatedUserEntity, IMapFrom<UserSport>
    {
        public Sport Sport { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserSport, UserSportRequest>().ReverseMap();
        }
    }
}