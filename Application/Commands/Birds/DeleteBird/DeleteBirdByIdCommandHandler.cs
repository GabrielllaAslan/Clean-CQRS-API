using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = _mockDatabase.Birds.Where(bird => bird.Id == request.Id).FirstOrDefault()!;

            _mockDatabase.Birds.Remove(birdToDelete);

            return Task.FromResult(birdToDelete);
        }
    }
}
