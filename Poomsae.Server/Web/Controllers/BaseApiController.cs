using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Poomsae.Server.Web.Controllers
{
    [EnableRateLimiting("jofa")]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
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