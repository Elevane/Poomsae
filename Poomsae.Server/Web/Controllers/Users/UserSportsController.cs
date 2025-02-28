using Microsoft.AspNetCore.Mvc;
using Poomsae.Application.Models.Dtos.Users.Requests;
using Poomsae.Application.Models.Dtos.Users.Responses;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Application.Services.UserSports.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Web.Authentification.Attributes;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers.Users
{
    [UserController]
    public class UserSportsController : GenericUsersController<UserSport, UserSportRequest, UserSportResponse>
    {
        public UserSportsController(IHttpContextAccessor httpContextAccessor, IGenericUsersService<UserSport, UserSportRequest, UserSportResponse> service) : base(httpContextAccessor, service)
        {
        }
    }
}