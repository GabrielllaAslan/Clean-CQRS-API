using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Users
{
    internal sealed class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, User>
    {
        private readonly MockDatabase _mockDatabase;

        public AddNewUserCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<User> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            User userToCreate = new()
            {
                Id = Guid.NewGuid(),
                UserName = request.NewUser.UserName,
                Password = request.NewUser.Password,
            };

            _mockDatabase.Users.Add(userToCreate);
            return Task.FromResult(userToCreate);
        }
    }
}
