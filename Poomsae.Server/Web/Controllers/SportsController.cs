using Microsoft.AspNetCore.Mvc;
using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Application.Models.Sports;
using Poomsae.Server.Application.Services.Interfaces;

namespace Poomsae.Server.Web.Controllers
{
    public class SportsController : BaseApiController
    {
        private readonly ISportsService _service;

        public SportsController(ISportsService service) => _service = service;

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetSports(int userId)
        {
            Result<List<SportResponse>> res = await _service.GetSports(userId);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(res.Value);
        }
    }
}