using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Dtos.Authentification
{
    public class ApplicationUser : IMapFrom<User>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public int? Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, User>().ReverseMap();
        }
    }
}