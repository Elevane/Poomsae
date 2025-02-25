using Poomsae.Application.Models.Dtos.References.Requests;
using Poomsae.Application.Models.Dtos.References.Responses;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers
{
    public class MovementsController : GenericController<Movement, MovementRequest, MovementResponse>
    {
        public MovementsController(IHttpContextAccessor httpContextAccessor, IGenericService<Movement, MovementRequest, MovementResponse> service) : base(httpContextAccessor, service)
        {
        }
    }
}