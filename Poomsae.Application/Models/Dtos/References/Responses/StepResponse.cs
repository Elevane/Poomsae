using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Application.Models.Dtos.References.Responses
{
    public class StepResponse : BaseEntity, IMapFrom<Step>
    {
        public int Order { get; set; }
        public List<Movement> Movements { get; set; } = [];

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Step, StepResponse>().ReverseMap();
        }
    }
}