using Application.Queries.Cats.GetWeight;
using Domain.Models;
using Infrastructure.Repository.CatRepository; 
using MediatR;

namespace Application.Queries.Cats.GetWeightAndBreed 
{
    public class GetCatsByWeightOrBreedQueryHandler : IRequestHandler<GetCatsByWeightOrBreedQuery, List<Cat>> 
    {
        private readonly ICatRepository _catRepository; 

        public GetCatsByWeightOrBreedQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository; 
        }

        public async Task<List<Cat>> Handle(GetCatsByWeightOrBreedQuery request, CancellationToken cancellationToken)
        {
            List<Cat> cats = await _catRepository.GetCatsByWeightBreed(request.Weight, request.Breed, cancellationToken); 

            return cats;
        }
    }
}
