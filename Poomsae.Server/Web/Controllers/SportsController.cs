using Microsoft.AspNetCore.Mvc;
using Poomsae.Application.Models.Dtos.Sports;
using Poomsae.Application.Models.Dtos.Sports.Requests;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.Sports.Interfaces;
using Poomsae.Server.Web.Authentification.Attributes;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers
{
    [Private]
    public class SportsController : BaseApiController
    {
        private readonly ISportsService _service;

        public SportsController(ISportsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
            if (ApplicationUser == null)
                throw new ArgumentNullException();
        }

        [HttpGet]
        public async Task<IActionResult> GetSports()
        {
            Result<List<SportResponse>> res = await _service.GetSports((int)ApplicationUser.Id);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(res.Value);
        }

        [HttpPost("{sportId}")]
        public async Task<IActionResult> Add(int sportId)
        {
            Result res = await _service.AddSport(sportId, (int)ApplicationUser.Id);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSportRequest request)
        {
            Result<CreateSportRequest> res = await _service.Create(request, (int)ApplicationUser.Id);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(res.Value);
        }
    }
}