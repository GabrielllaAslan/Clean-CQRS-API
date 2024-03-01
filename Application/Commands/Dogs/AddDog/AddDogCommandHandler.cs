using Domain.Models;
using Infrastructure.Repository.DogRepository;
using MediatR;

namespace Application.Commands.Dogs
{
    public sealed class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;

        public AddDogCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewDog.Name,
                Breed = request.NewDog.Breed,
                Weight = request.NewDog.Weight,
               
            };

            _dogRepository.AddDog(dogToCreate, cancellationToken);

            return Task.FromResult(dogToCreate);
        }
    }
}