using Microsoft.AspNetCore.Mvc;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Domain.Entitites.Base.Interfaces;
using Poomsae.Server.Domain.Entities.Base;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;
using Poomsae.Server.Web.Authentification.Attributes;

namespace Poomsae.Server.Web.Controllers.Base
{
    [UserController]
    public class GenericUsersController<T, TRequest, TResponse> : BaseApiController where T : class, IAssociatedUserEntity
       where TRequest : class, IEntity
       where TResponse : class, IBaseEntity
    {
        private readonly IGenericUsersService<T, TRequest, TResponse> _service;

        public GenericUsersController(IHttpContextAccessor httpContextAccessor, IGenericUsersService<T, TRequest, TResponse> service) : base(httpContextAccessor)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TRequest request)
        {
            Result result = await _service.Create(request, (int)ApplicationUser.Id);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Put(TRequest request)
        {
            Result result = await _service.Update(request, (int)ApplicationUser.Id);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Result<TResponse> result = await _service.Get(id);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<List<TResponse>> result = await _service.GetAll((int)ApplicationUser.Id);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Result result = await _service.Delete(id, (int)ApplicationUser.Id);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return NoContent();
        }
    }
}