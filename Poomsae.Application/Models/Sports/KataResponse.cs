using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Sports
{
    public class KataResponse : GenericParentResponse<StepResponse>, IMapFrom<Kata>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Kata, KataResponse>().ReverseMap();
        }
    }
}