using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Cat> AddCat(Cat newCat)
        {
            try
            {
                _realDatabase.Cats.Add(newCat);
                _realDatabase.SaveChanges();
                return await Task.FromResult(newCat);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<Cat> AddCat(Cat newCat, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Cat> DeleteCatById(Guid id)
        {
            try
            {
                Cat catToDelete = await GetCatById(id);

                _realDatabase.Cats.Remove(catToDelete);

                _realDatabase.SaveChanges();

                return await Task.FromResult(catToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting a cat with Id {id} from the database", ex);
            }
        }

        public async Task<List<Cat>> GetAllCatsAsync()
        {
            try
            {
                return await _realDatabase.Cats.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all cats from the database", ex);
            }
        }

        public async Task<Cat> GetCatById(Guid catId)
        {
            try
            {
                Cat? wantedCat = await _realDatabase.Cats.FirstOrDefaultAsync(cat => cat.Id == catId);

                if (wantedCat == null)
                {
                    throw new Exception($"There was no cat with Id {catId} in the database");
                }

                return await Task.FromResult(wantedCat);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting a cat by Id {catId} from the database", ex);
            }
        }

        public Task<List<Cat>> GetCatsByWeightBreed(int? weight, string? breed)
        {
            throw new NotImplementedException();
        }

        public async Task<Cat> UpdateCat(Cat updatedCat)
        {
            try
            {
                _realDatabase.Cats.Update(updatedCat);

                _realDatabase.SaveChanges();

                return await Task.FromResult(updatedCat);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating a cat by Id {updatedCat.Id} from the database", ex);
            }
        }
    }
}
