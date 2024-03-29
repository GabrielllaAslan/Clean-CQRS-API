﻿using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToUpdate = _mockDatabase.Birds.Where(bird => bird.Id == request.Id).FirstOrDefault()!;

            birdToUpdate.Name = request.BirdToUpdate.Name;
            birdToUpdate.CanFly = request.BirdToUpdate.CanFly;

            return Task.FromResult(birdToUpdate);
        }
    }
}
