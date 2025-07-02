using BuildingManagement.Application.Features.Commands.ApartmentUserCommands.CreateApartmentUser;
using BuildingManagement.Application.Features.Queries.ApartmentUserQueries.GetAllApartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApartmentUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-apartment-user")]
        public async Task<IActionResult> CreateApartmentUser([FromBody] CreateApartmentUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("all-apartment-user")]
        public async Task<IActionResult> GetAllApartments([FromQuery] GetAllApartmentUserQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
