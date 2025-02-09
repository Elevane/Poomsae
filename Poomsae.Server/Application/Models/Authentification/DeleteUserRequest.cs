using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poomsae.Server.Application.Models.Authentification
{
    public class DeleteUserRequest : IMapFrom<User>
    {
        public string? Email { get; set; }

        public bool IsAnonimise { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, DeleteUserRequest>().ReverseMap();
        }
    }
}
