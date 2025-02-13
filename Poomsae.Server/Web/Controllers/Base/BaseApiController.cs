using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Web.Controllers.Base
{
    [EnableRateLimiting("poomsae")]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        private IHttpContextAccessor HttpContextAccessor;
        protected User? ApplicationUser;

        public BaseApiController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
            ApplicationUser = HttpContextAccessor?.HttpContext?.Items["User"] as User;
        }

        protected ActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(Dictionary<string, string> errorMessages)
        {
            return BadRequest(Envelope.Error(errorMessages));
        }

        protected ActionResult BadRequest(Dictionary<string, string> errorMessages)
        {
            return base.BadRequest(Envelope.Error(errorMessages));
        }

        protected ActionResult NotFound(Dictionary<string, string> errorMessages)
        {
            return base.NotFound(Envelope.Error(errorMessages));
        }
    }
}