using AutoMapper;
using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Application.Models.Sports.Requests
{
    public class CreateSportRequest : IMapFrom<Sport>
    {
        public string Ecole { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sport, CreateSportRequest>().ReverseMap();
        }
    }
}