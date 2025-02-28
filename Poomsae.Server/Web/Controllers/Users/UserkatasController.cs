using Poomsae.Application.Models.Dtos.Users.Requests;
using Poomsae.Application.Models.Dtos.Users.Responses;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Web.Authentification.Attributes;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers.Users
{
    [UserController]
    public class UserKatasController : GenericUsersController<UserKata, UserKataRequest, UserKataResponse>
    {
        public UserKatasController(IHttpContextAccessor httpContextAccessor, IGenericUsersService<UserKata, UserKataRequest, UserKataResponse> service) : base(httpContextAccessor, service)
        {
        }
    }
}