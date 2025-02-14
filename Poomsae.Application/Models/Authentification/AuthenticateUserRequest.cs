﻿using System.ComponentModel.DataAnnotations;

namespace Poomsae.Application.Models.Authentification
{
    public class AuthenticateUserRequest
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
