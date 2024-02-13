using Domain.Models;
using Infrastructure.Repository.DogRepository;
using MediatR;

namespace Application.Commands.Dogs
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;

        public AddDogCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {

            Dog dogToCreate = new()
            {
                Name = request.NewDog.Name,
                Breed = request.NewDog.Breed,
                Weight = request.NewDog.Weight
            };


            await _dogRepository.AddDog(dogToCreate, request.Id);


            return dogToCreate;
        }

    }
}
