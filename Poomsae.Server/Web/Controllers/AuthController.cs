using Microsoft.AspNetCore.Mvc;
using Poomsae.Server.Application.Interfaces;
using Poomsae.Server.Application.Models.Authentification;
using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Web.Controllers;

namespace Poomsae.Server.Web.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

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
        }

        [HttpPatch("[action]/{token}")]
        public async Task<IActionResult> confirm(string token)
        {
            Result res = await _authService.ConfirmAccount(token);
            if (res.IsFailure)
                return BadRequest(res.Errors);
            return Ok(token);
        }*/


    }
}