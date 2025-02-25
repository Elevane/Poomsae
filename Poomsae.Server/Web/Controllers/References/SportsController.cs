using Poomsae.Application.Models.Dtos.References.Requests;
using Poomsae.Application.Models.Dtos.References.Responses;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Web.Controllers.Base;

namespace Poomsae.Server.Web.Controllers.References
{
    public class SportsController : GenericController<Sport, SportRequest, SportResponse>
    {
        public SportsController(IHttpContextAccessor httpContextAccessor, IGenericService<Sport, SportRequest, SportResponse> service) : base(httpContextAccessor, service)
        {
        }
    }
}