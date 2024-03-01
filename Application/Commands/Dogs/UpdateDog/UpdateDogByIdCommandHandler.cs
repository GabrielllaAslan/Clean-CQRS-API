using Domain.Models;
using Infrastructure.Repository.DogRepository;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;

        public UpdateDogByIdCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            var Id = request.Id;
            var Name = request.UpdatedDog.Name;
            var Breed = request.UpdatedDog.Breed;
            int Weight = request.UpdatedDog.Weight;

            Dog dogToUpdate = await _dogRepository.UpdateDog(Id, Name, Breed, Weight, cancellationToken);

            return dogToUpdate;
        }
    }
}
