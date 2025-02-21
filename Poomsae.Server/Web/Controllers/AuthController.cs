using Microsoft.AspNetCore.Mvc;
using Poomsae.Application.Models.Dtos.Authentification;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.Authentification.Interfaces;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) => _authService = authService;

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserRequest user)
        {
            Result<RegisteredUser> res = await _authService.CreateUserAsync(user);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(res.Value);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(AuthenticateUserRequest toAuthenticate)
        {
            Result<RegisteredUser> res = await _authService.AuthenticateUserAsync(toAuthenticate);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(res.Value);
        }

        /*[HttpDelete("[action]")]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            Result res = await _authService.DeleteOrAnonymise(request);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(request);
        }*/

        [HttpPatch("[action]/{token}")]
        public async Task<IActionResult> confirm(string token)
        {
            Result res = await _authService.ConfirmAccount(token);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(token);
        }
    }
}