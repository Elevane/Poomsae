﻿using AutoMapper;
using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Application.Models.Sports
{
    public class StepResponse : GenericParentResponse<MovementResponse>, IMapFrom<Step>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Step, StepResponse>().ReverseMap();
        }
    }
}