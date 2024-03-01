using Domain.Models;
using Infrastructure.Repository.DogRepository;
using MediatR;

namespace Application.Queries.Dogs.GetWeightAndBreed
{
    public class GetDogsByWeightOrBreedQueryHandler : IRequestHandler<GetDogsByWeightOrBreedQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;

        public GetDogsByWeightOrBreedQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<List<Dog>> Handle(GetDogsByWeightOrBreedQuery request, CancellationToken cancellationToken)
        {
            List<Dog> dogs = await _dogRepository.GetDogsByWeightBreed(request.Weight, request.Breed, cancellationToken);

            return dogs;
        }
    }
}
