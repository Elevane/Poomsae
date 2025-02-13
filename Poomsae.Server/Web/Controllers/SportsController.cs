using Microsoft.AspNetCore.Mvc;
using Poomsae.Server.Application.Models.Authentification;
using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Application.Models.Sports;
using Poomsae.Server.Application.Models.Sports.Requests;
using Poomsae.Server.Application.Services.Interfaces;
using Poomsae.Server.Web.Authentification;

namespace Poomsae.Server.Web.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> GetSports(CreateSportRequest request)
        {
            Result<CreateSportRequest> res = await _service.Create(request, (int)ApplicationUser.Id);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(res.Value);
        }
    }
}