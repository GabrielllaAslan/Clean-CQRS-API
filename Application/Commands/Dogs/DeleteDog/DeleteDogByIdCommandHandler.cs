﻿using Application.Validators.Dog;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Repository.DogRepository;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly DogValidator _dogValidator;
        private MockDatabase database;

        public DeleteDogByIdCommandHandler(MockDatabase database)
        {
            this.database = database;
        }

        public DeleteDogByIdCommandHandler(IDogRepository dogRepository, DogValidator validator)
        {
            _dogRepository = dogRepository;
            _dogValidator = validator;
        }
        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {

            Dog dogToDelete = await _dogRepository.GetDogById(request.Id);

            if (dogToDelete == null)
            {
                return null!;
            }

            await _dogRepository.DeleteDogById(dogToDelete.Id);

            return dogToDelete;
        }
    }
}
