using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Repository.DogRepository;
using MediatR;

namespace Application.Queries.Dogs
{
    public sealed class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;

        public GetAllDogsQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromMockDatabase = Task.Run(() => _dogRepository.GetAllDogsAsync(cancellationToken)).Result;
            return Task.FromResult(allDogsFromMockDatabase);
        }
    }
}
