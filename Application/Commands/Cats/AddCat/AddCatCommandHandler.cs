using Application.Commands.Cats.AddCat;
using Domain.Models;
using Infrastructure.Repository.CatRepository;
using MediatR;

namespace Application.Commands.Cats
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public AddCatCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            Cat catToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay,
                Breed = request.NewCat.Breed,
                Weight = request.NewCat.Weight,
            };

            _catRepository.AddCat(catToCreate, cancellationToken);

            return Task.FromResult(catToCreate);
        }
    }
}
