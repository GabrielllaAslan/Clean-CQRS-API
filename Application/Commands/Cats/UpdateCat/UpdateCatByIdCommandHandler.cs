﻿using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateCatByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _mockDatabase.Cats.Where(cat => cat.Id == request.Id).FirstOrDefault()!;

            catToUpdate.Name = request.CatToUpdate.Name;
            catToUpdate.LikesToPlay = request.CatToUpdate.LikesToPlay;

            return Task.FromResult(catToUpdate);
        }
    }
}
