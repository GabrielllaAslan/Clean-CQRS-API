﻿using Domain.Models;
using Infrastructure.Repository.CatRepository; 
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat> 
    {
        private readonly ICatRepository _catRepository; 

        public GetCatByIdQueryHandler(ICatRepository catRepository) 
        {
            _catRepository = catRepository;
        }

        public Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = Task.Run(() => _catRepository.GetCatById(request.Id, cancellationToken)).Result;

            return Task.FromResult(wantedCat);
        }
    }
}
