using AutoMapper;
using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites.Base;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Application.Models.Sports
{
    public class KataResponse : GenericParentResponse<StepResponse>, IMapFrom<Kata>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Kata, KataResponse>().ReverseMap();
        }
    }
}