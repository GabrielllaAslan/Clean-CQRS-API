using Domain.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.DogRepository
{
    public class DogRepository : IDogRepository
    {
        private readonly RealDatabase _realDatabase;


        public DogRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Dog> AddDog(Dog newDog, CancellationToken cancellationToken)
        {
            _realDatabase.Dogs.Add(newDog);
            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(newDog);
        }

        public Task<Dog> DeleteDog(Guid id, CancellationToken cancellationToken)
        {
            var dogToDelete = _realDatabase.Dogs.FirstOrDefault(b => b.Id == id);

            _realDatabase.Remove(dogToDelete!);
            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(dogToDelete!);
        }

        public Task<List<Dog>> GetAllDogsAsync(CancellationToken cancellationToken)
        {
            List<Dog> allDogs = _realDatabase.Dogs.ToList();

            return Task.FromResult(allDogs);
        }

        public Task<Dog> GetDogById(Guid id, CancellationToken cancellationToken)
        {
            Dog wantedDog = _realDatabase.Dogs.FirstOrDefault(b => b.Id == id);

            return Task.FromResult(wantedDog!);
        }

        public Task<List<Dog>> GetDogsByWeightBreed(int? weight, string? breed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Dog> UpdateDog(Guid id, string name, string breed, int weight, CancellationToken cancellationToken)
        {
            Dog DogUpdate = _realDatabase.Dogs.FirstOrDefault(b => b.Id == id);

            DogUpdate.Name = name;
            DogUpdate.Weight = weight;
            DogUpdate.Breed = breed;
          

            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(DogUpdate);
        }
    }
}

       
