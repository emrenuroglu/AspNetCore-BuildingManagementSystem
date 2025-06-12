using BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment;
using BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
       private readonly IMediator _mediator;

        public ApartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateApartment([FromBody] CreateApartmentCommandRequest createApartmentCommandRequest)
        {
            var result = await _mediator.Send(createApartmentCommandRequest);
            return Ok(result);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllApartmentQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
