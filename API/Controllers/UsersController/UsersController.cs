using Application.Commands.AnimalToUser;
using Application.Commands.Users;
using Application.Commands.Users.AddUser;
using Application.Dtos;
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

        [HttpPost("addNewAnimal")]
        public async Task<IActionResult> AddNewAnimal([FromBody] AddNewAnimalCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result)
                {
                    return Ok("Animal added successfully");
                }
                else
                {
                    return BadRequest("Failed to add animal");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

            [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userWantingToLogIn)
        {
            return Ok(await _mediator.Send(new LoginUserQuery(userWantingToLogIn)));

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto newUser)
        {
            return Ok(await _mediator.Send(new AddNewUserCommand(newUser)));

        }

    }

}

