﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Web.Authentification.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminControllerAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            User? token = context.HttpContext.Items[key: ContextValues.User] as User;
            if (token == null || token?.Role != Role.admin)
                context.Result = new JsonResult(new { Errors = "Unauthorized request" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}