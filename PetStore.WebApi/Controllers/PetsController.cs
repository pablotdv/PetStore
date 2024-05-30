using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore.Application;
using PetStore.Application.Pets;

namespace PetStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PetsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            GetPetByIdRequest request = new GetPetByIdRequest { Id = id };  
            var response = await _mediator.Send(request);
            if (response is NotFoundResponse)
                return NotFound();
            return Ok(response);
        }
    }
}
