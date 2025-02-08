using Poomsae.Server.Application.Utils.Mapping;
using Poomsae.Server.Domain.Entities;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Poomsae.Server.Application.Models.Authentification
{
    public class RegisterUserRequest : IMapFrom<User>
    {
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterUserRequest, User>().ReverseMap();
        }

    }
}
