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
        [HttpPost("create-apartment")]
        public async Task<IActionResult> CreateApartment([FromBody] CreateApartmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("all-apartments")]
        public async Task<IActionResult> GetAllApartments([FromQuery] GetAllApartmentQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
