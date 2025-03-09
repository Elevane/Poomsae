using Poomsae.Application.Models.Dtos.References.Requests;
using Poomsae.Application.Models.Dtos.References.Responses;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers
{
    public class KatasController : GenericReferencesController<Kata, KataRequest, KataResponse>
    {
        public KatasController(IHttpContextAccessor httpContextAccessor, IGenericReferencesService<Kata, KataRequest, KataResponse> service) : base(httpContextAccessor, service)
        {
        }
    }
}