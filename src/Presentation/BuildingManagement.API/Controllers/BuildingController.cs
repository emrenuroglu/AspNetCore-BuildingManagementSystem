using BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment;
using BuildingManagement.Application.Features.Commands.ApartmentCommands.RemoveApartment;
using BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment;
using BuildingManagement.Application.Features.Queries.ApartmentQueries.GetByIdApartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateApartment([FromBody] CreateBuildingCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBuildingQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("şart")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdBuildingQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("sil")]
        public async Task<IActionResult> RemoveApartment([FromQuery] RemoveBuildingCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
