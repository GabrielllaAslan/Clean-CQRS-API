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
            // Password hashing using BCrypt
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);

            User userToCreate = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.NewUser.UserName,
                Password = hashedPassword,
            };

            // Anropa metod i UserRepository för att lägga till användaren i databasen
            await _userRepository.AddUserAsync(userToCreate);

            return userToCreate;
        }
    }
}

