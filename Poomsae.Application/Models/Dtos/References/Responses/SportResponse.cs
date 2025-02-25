using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Application.Models.Dtos.References.Responses
{
    public class SportResponse : BaseEntity, IMapFrom<Sport>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sport, SportResponse>().ReverseMap();
        }
    }
}