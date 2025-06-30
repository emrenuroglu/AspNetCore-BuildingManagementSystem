using BuildingManagement.Application.Features.Commands.UserCommands.CreateUser;
using BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment;
using BuildingManagement.Application.Features.Queries.UserQueries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}
