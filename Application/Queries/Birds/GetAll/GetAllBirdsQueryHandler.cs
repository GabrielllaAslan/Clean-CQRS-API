using Application.Queries.Birds.GetAll;
using Domain.Models;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repository.BirdRepository; 
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Birds 
{
    public sealed class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>> 
    {
        private readonly IBirdRepository _birdRepository; 

        public GetAllBirdsQueryHandler(IBirdRepository birdRepository) 
        {
            _birdRepository = birdRepository; 
        }

        public async Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken) 
        {
            List<Bird> allBirdsFromMockDatabase = await _birdRepository.GetAllBirdsAsync(cancellationToken);

            return allBirdsFromMockDatabase;
        }
    }
}
