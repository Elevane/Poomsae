using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Dtos.Users.Requests
{
    public class UserKataRequest : AssociatedUserEntity, IMapFrom<UserKata>
    {
        public Kata Kata { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserKata, UserKataRequest>().ReverseMap();
        }
    }
}