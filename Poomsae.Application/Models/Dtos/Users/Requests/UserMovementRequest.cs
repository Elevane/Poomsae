using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Dtos.Users.Requests
{
    public class UserMovementRequest : AssociatedUserEntity, IMapFrom<UserMovement>
    {
        public Movement Movement { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserMovement, UserMovementRequest>().ReverseMap();
        }
    }
}