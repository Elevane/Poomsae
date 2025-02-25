using Microsoft.AspNetCore.Mvc;
using Poomsae.Application.Models.Monads.Errors;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Domain.Entitites.Base.Interfaces;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;
using Poomsae.Server.Web.Authentification.Attributes;

namespace Poomsae.Server.Web.Controllers.Base
{
    [Private]
    public class GenericController<T, R1, R2> : BaseApiController where T : class, IBaseEntity
        where R1 : class, IEntity
        where R2 : class, IBaseEntity
    {
        private readonly IGenericService<T, R1, R2> _service;

        public GenericController(IHttpContextAccessor httpContextAccessor, IGenericService<T, R1, R2> service) : base(httpContextAccessor)
        {
            _service = service;
        }

        public GenericController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(R1 request)
        {
            Result<T> result = await _service.Create(request);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Put(R1 request)
        {
            Result<T> result = await _service.Update(request);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Result<T> result = await _service.Get(id);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<List<T>> result = await _service.GetAll();
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Result<T> result = await _service.Delete(id);
            if (result.IsFailure)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }
    }
}