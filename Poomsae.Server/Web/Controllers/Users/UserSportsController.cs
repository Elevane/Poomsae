using Microsoft.AspNetCore.Mvc;
using Poomsae.Application.Models.Dtos.UserSports.Requests;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.UserSports.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Web.Authentification.Attributes;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers.Users
{
    [Authorize]
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
            Result res = await _service.AddSport(request, ApplicationUser.Id);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            Result<List<UserSport>> res = await _service.GetAll(ApplicationUser.Id);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(res.Value);
        }
    }
}