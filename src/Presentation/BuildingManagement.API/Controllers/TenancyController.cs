using BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment;
using BuildingManagement.Application.Features.Commands.ApartmentUserCommands.UpdateApartmentUser;
using BuildingManagement.Application.Features.Commands.TenancyCommands.CreateTenancy;
using BuildingManagement.Application.Features.Commands.TenancyCommands.UpdateTenancy;
using BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment;
using BuildingManagement.Application.Features.Queries.TenancyQueries.GetAllTenancies;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenancyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenancyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create-tenancy")]
        public async Task<IActionResult> CreateTenancy([FromBody] CreateTenancyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("all-Tenancy")]
        public async Task<IActionResult> GetAllTenancy([FromQuery] GetAllTenancyQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("update-tenancy")]
        public async Task<IActionResult> UpdateTenancy([FromBody] UpdateTenancyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateApartmentUserCommandRequest request)
        {
            if (id != request.Id)
                return BadRequest("URL'deki ID ile body'deki ID uyuşmuyor.");

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
