using Poomsae.Application.Models.Dtos.References.Requests;
using Poomsae.Application.Models.Dtos.References.Responses;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers
{
    public class StepsController : GenericController<Step, StepRequest, StepResponse>
    {
        public StepsController(IHttpContextAccessor httpContextAccessor, IGenericService<Step, StepRequest, StepResponse> service) : base(httpContextAccessor, service)
        {
        }
    }
}