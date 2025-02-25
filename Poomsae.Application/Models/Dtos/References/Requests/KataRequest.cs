using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Domain.Entitites.Base;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Dtos.References.Requests
{
    public class KataRequest : Entity, IMapFrom<Kata>
    {
        public string Ecole { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Kata, KataRequest>().ReverseMap();
        }
    }
}