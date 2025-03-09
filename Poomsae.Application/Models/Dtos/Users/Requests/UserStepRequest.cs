using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Dtos.Users.Requests
{
    public class UserStepRequest : AssociatedUserEntity, IMapFrom<UserStep>
    {
        public Step Step { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserStep, UserStepRequest>().ReverseMap();
        }
    }
}