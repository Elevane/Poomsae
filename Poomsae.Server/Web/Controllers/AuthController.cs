using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            Result res = await _authService.DeleteOrAnonymise(request);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(request);
        }

        [HttpPatch("[action]/{token}")]
        public async Task<IActionResult> Confirm(string token)
        {
            Result res = await _authService.ConfirmAccount(token);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(token);
        }

        [HttpPatch("[action]/{email}")]
        public async Task<IActionResult> Reset(string email)
        {
            Result res = await _authService.ResetPassword(email);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return NoContent();
        }

        [HttpPatch("[action]/{token}")]
        public async Task<IActionResult> ValidateToken(string token)
        {
            Result res = await _authService.ValidateChangePassorwToken(token);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return NoContent();
        }

        [HttpPatch("[action]/{token}")]
        public async Task<IActionResult> ChangePassword(string token, RegisterUserRequest request)
        {
            Result res = await _authService.ChangePassword(token, request);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return NoContent();
        }
    }
}