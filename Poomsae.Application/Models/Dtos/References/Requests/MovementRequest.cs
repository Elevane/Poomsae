using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Domain.Entitites.Base;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Application.Models.Dtos.References.Requests
{
    public class MovementRequest : Entity, IMapFrom<Movement>
    {
        public string? BodyPart { get; set; }

        public string? From { get; set; }

        public string? To { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Movement, MovementRequest>().ReverseMap();
        }
    }
}