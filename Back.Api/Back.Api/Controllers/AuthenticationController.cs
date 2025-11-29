using Back.Api.Application.Services.Authentication.Commands.Login;
using Back.Api.Application.Services.Authentication.Dto;
using Back.Api.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = new BaseResponseModel<SessionDto>();
            response.Data = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
