using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Users
{
    public class AddNewUserCommand : IRequest<User>
    {

        public AddNewUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }

        public UserDto NewUser { get; }
    }
}
