using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Authentification
{
    public class DeleteUserRequest : IMapFrom<User>
    {
        public string? Email { get; set; }

        public bool IsAnonimise { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, DeleteUserRequest>().ReverseMap();
        }
    }
}
