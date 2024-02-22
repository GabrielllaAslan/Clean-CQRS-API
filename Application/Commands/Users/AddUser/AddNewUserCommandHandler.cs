using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Repository.UserRepository;
using MediatR;
using System;

namespace Application.Commands.Users.AddUser
{
    internal sealed class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public AddNewUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            User userToCreate = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.NewUser.UserName,
                Password = request.NewUser.Password,
            };

            // Anropa metod i UserRepository för att lägga till användaren i databasen
            await _userRepository.AddUserAsync(userToCreate);

            return userToCreate;
        }
    }
}

