﻿using AutoMapper;
using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Application.Models.Sports
{
    public class UserResponse : IMapFrom<User>
    {
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserResponse, User>().ReverseMap();
        }
    }
}