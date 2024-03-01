using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CatRepository 
{
    public interface ICatRepository 
    {
        Task<List<Cat>> GetAllCatsAsync(CancellationToken cancellationToken); 
        Task<Cat> GetCatById(Guid id, CancellationToken cancellationToken); 
        Task<Cat> AddCat(Cat newCat, CancellationToken cancellationToken); 
        Task<List<Cat>> GetCatsByWeightBreed(int? weight, string? breed, CancellationToken cancellationToken);
        Task<Cat> DeleteCat(Guid? id, CancellationToken cancellationToken);
        Task<Cat> UpdateCat(Guid id, string name, bool likesToPlay, string breed, int weight, CancellationToken cancellationToken);
    }
}