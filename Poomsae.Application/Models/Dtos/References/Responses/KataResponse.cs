using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Domain.Entitites.Base;

namespace Poomsae.Application.Models.Dtos.References.Responses
{
    public class KataResponse : BaseEntity, IMapFrom<Kata>
    {
        public int Order { get; set; }

        public List<Step> Steps { get; set; } = [];

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Kata, KataResponse>().ReverseMap();
        }
    }
}