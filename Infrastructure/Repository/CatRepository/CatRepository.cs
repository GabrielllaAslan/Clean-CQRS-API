using Domain.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Infrastructure.Repository.CatRepository
{
    public class CatRepository : ICatRepository
    {
        private readonly RealDatabase _realDatabase;
        // Implement ILogger if needed

        public CatRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Cat> AddCat(Cat newCat, CancellationToken cancellationToken)
        {
            _realDatabase.Cats.Add(newCat);
            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(newCat);
        }

        public Task<Cat> DeleteCat(Guid? id, CancellationToken cancellationToken)
        {
            var catToDelete = _realDatabase.Cats.FirstOrDefault(b => b.Id == id);

            _realDatabase.Remove(catToDelete!);
            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(catToDelete!);
        }

        public Task<List<Cat>> GetAllCatsAsync(CancellationToken cancellationToken)
        {
            List<Cat> allCats = _realDatabase.Cats.ToList();

            return Task.FromResult(allCats);
        }

        public Task<Cat> GetCatById(Guid id, CancellationToken cancellationToken)
        {
            Cat wantedCat = _realDatabase.Cats.FirstOrDefault(b => b.Id == id);

            return Task.FromResult(wantedCat!);
        }

        public Task<List<Cat>> GetCatsByWeightBreed(int? weight, string? breed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Cat> UpdateCat(Guid id, string name, bool likesToPlay, string breed, int weight, CancellationToken cancellationToken)
        {
            Cat CatUpdate = _realDatabase.Cats.FirstOrDefault(b => b.Id == id);

            CatUpdate.Name = name;
            CatUpdate.Weight = weight;
            CatUpdate.Breed = breed;
            CatUpdate.LikesToPlay = likesToPlay;

            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(CatUpdate);
        }
    }
}
