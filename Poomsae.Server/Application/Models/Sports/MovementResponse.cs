using AutoMapper;
using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Application.Models.Sports
{
    public class MovementResponse : IMapFrom<Movement>
    {
        public string BodyPart { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Movement, MovementResponse>().ReverseMap();
        }
    }
}