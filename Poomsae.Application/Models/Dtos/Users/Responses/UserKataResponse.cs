using AutoMapper;
using Poomsae.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poomsae.Application.Models.Dtos.Users.Responses
{
    public class UserKataResponse : AssociatedUserEntity, IMapFrom<UserKata>
    {
        public Kata Kata { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Kata, UserKataResponse>().ReverseMap();
        }
    }
}