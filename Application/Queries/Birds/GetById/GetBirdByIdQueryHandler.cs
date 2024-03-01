using Domain.Models;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repository.BirdRepository; 
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetById 
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird> 
    {
        private readonly IBirdRepository _birdRepository;

        public GetBirdByIdQueryHandler(IBirdRepository birdRepository) 
        {
            _birdRepository = birdRepository; 
        }

        public async Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken) 
        {
            Bird wantedBird = await _birdRepository.GetBirdById(request.Id, cancellationToken);

            return wantedBird;
        }
    }
}
