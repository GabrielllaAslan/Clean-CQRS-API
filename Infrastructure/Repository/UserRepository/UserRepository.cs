﻿using Domain.Models;
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
        public async Task AddUserAsync(User user)
        {
            try
            {
                // Assuming User has a corresponding DbSet in your DbContext
                await _realDatabase.Users.AddAsync(user);
                await _realDatabase.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                throw;
            }
        }

        public Task<List<User>> GetAllUsers(string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
   