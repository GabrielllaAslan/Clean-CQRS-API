using Application.Commands.Users;
using Application.Dtos;
using Application.Queries.Users.GetAllUsers;
using Application.Queries.Users.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsersQuery()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto newUser)
        {
            return Ok(await _mediator.Send(new AddNewUserCommand(newUser)));

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userWantingToLogIn)
        {
            return Ok(await _mediator.Send(new LoginUserQuery(userWantingToLogIn)));

        }

    }

}
