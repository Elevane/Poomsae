using AutoMapper;
using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Application.Models.Authentification
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
