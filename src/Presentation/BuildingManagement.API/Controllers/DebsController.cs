using BuildingManagement.Application.Features.Commands.DebsCommands.CreateDebs;
using BuildingManagement.Application.Features.Queries.DebsQueries.GetAllDebs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DebsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateDebs([FromBody] CreateDebsCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDebs([FromQuery] GetAllDebsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
