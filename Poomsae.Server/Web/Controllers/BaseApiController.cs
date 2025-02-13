using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Poomsae.Server.Application.Models.Authentification;

namespace Poomsae.Server.Web.Controllers
{
    [EnableRateLimiting("poomsae")]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        private IHttpContextAccessor HttpContextAccessor;
        protected ApplicationUser? ApplicationUser;

        public BaseApiController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
            ApplicationUser = HttpContextAccessor?.HttpContext?.Items["User"] as ApplicationUser;
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