using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Dtos.Sports
{
    public class UserResponse : IMapFrom<User>
    {
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserResponse, User>().ReverseMap();
        }
    }
}