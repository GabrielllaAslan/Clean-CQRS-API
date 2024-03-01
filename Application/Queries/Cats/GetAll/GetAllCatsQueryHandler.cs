using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Cats.GetAll; 
using Domain.Models;
using Infrastructure.Repository.CatRepository; 
using MediatR;

namespace Application.Queries.Cats 
{
    public sealed class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>> 
    {
        private readonly ICatRepository _catRepository; 

        public GetAllCatsQueryHandler(ICatRepository catRepository) 
        {
            _catRepository = catRepository; 
        }

        public Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsFromMockDatabase = Task.Run(() => _catRepository.GetAllCatsAsync(cancellationToken)).Result;             return Task.FromResult(allCatsFromMockDatabase);
        }
    }
}
