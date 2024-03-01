using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Birds
{
    public class GetAllBirdsByColorQuery : IRequest<List<Bird>>
    {
        public string Color { get; set; }
    }

    public class GetAllBirdsByColorQueryHandler : IRequestHandler<GetAllBirdsByColorQuery, List<Bird>>
    {
        private readonly IBirdRepository _birdRepository;

        public GetAllBirdsByColorQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<List<Bird>> Handle(GetAllBirdsByColorQuery request, CancellationToken cancellationToken)
        {
            List<Bird> birds = await _birdRepository.GetAllBirdsByColor(request.Color, cancellationToken);
            return birds;
        }
    }
}

