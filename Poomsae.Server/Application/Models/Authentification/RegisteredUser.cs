using AutoMapper;
using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Application.Models.Authentification
{
    public class RegisteredUser : IMapFrom<User>
    {
        public string? Token { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisteredUser, User>().ReverseMap();
        }
    }
}
