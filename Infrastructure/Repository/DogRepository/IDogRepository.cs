using Domain.Models;

namespace Infrastructure.Repository.DogRepository
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogsAsync(CancellationToken cancellationToken);
        Task<Dog> GetDogById(Guid id, CancellationToken cancellationToken);
        Task<Dog> AddDog(Dog newDog,  CancellationToken cancellationToken);
        Task<List<Dog>> GetDogsByWeightBreed(int? weight, string? breed, CancellationToken cancellationToken);
        Task<Dog> DeleteDog(Guid id, CancellationToken cancellationToken);
        Task<Dog> UpdateDog(Guid id, string name, string breed, int weight, CancellationToken cancellationToken);
    }
}