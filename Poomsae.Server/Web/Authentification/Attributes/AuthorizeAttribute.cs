using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Poomsae.Application.Models.Authentification;

namespace Poomsae.Server.Web.Authentification.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ApplicationUser? token = context.HttpContext.Items[key: ContextValues.User] as ApplicationUser;
            if (token == null)
                context.Result = new JsonResult(new { Errors = "Unauthorized request" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}