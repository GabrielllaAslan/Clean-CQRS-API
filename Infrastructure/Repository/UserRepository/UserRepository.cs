using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase animalDbContext)
        {
            _realDatabase = animalDbContext;
        }

        public async Task<bool> AddUserAnimalAsync(UserAnimal userAnimal)
        {
            try
            {
                var user = await _realDatabase.Users.FirstOrDefaultAsync(u => u.Id == userAnimal.UserId);
                var animal = await _realDatabase.AnimalModels.FirstOrDefaultAsync(a => a.Id == userAnimal.AnimalId);

                if (user != null && animal != null)
                {
                    _realDatabase.UserAnimals.Add(userAnimal);
                    await _realDatabase.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Logga fel här om det behövs
                return false;
            }
        }
    }
}