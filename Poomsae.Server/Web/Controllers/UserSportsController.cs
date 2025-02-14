﻿using Microsoft.AspNetCore.Mvc;
using Poomsae.Application.Models.Errors;
using Poomsae.Application.Models.Sports;
using Poomsae.Application.Models.Sports.Requests;
using Poomsae.Application.Models.UserSports.Requests;
using Poomsae.Application.Services.Sports.Interfaces;
using Poomsae.Application.Services.UserSports.Interfaces;
using Poomsae.Server.Web.Authentification.Attributes;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers
{
    [Private]
    public class UserSportsController : BaseApiController
    {
        private readonly IUserSportsService _service;

        public UserSportsController(IUserSportsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
            if (ApplicationUser == null)
                throw new ArgumentNullException();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserSportsRequest request)
        {
            Result res = await _service.AddSport(request, (int)ApplicationUser.Id);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok();
        }
    }
}