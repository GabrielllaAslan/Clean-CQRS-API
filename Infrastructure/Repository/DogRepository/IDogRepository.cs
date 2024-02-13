using Domain.Models;

namespace Infrastructure.Repository.DogRepository
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogsAsync();
        Task<Dog> GetDogById(Guid id);
        Task<Dog> AddDog(Dog newDog, Guid id);
        Task<Dog> UpdateDog(Dog newDog);
        Task<Dog> DeleteDogById(Guid id);
        Task<List<Dog>> GetDogsByWeightBreed(int? weight, string? breed);
    }
}