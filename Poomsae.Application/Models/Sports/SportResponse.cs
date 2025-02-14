using AutoMapper;
using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Application.Models.Sports
{
    public class SportResponse : GenericParentResponse<KataResponse>, IMapFrom<Sport>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sport, SportResponse>().ReverseMap();
        }
    }
}