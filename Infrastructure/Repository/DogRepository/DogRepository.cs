﻿using Domain.Models;
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

        public async Task<Dog> AddDog(Dog newDog)
        {
            try
            {
                _realDatabase.Dogs.Add(newDog);
                _realDatabase.SaveChanges();
                return await Task.FromResult(newDog);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<Dog> AddDog(Dog newDog, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dog> DeleteDogById(Guid id)
        {
            try
            {
                Dog dogToDelete = await GetDogById(id);

                _realDatabase.Dogs.Remove(dogToDelete);

                _realDatabase.SaveChanges();

                return await Task.FromResult(dogToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while deleting a dog with Id {id} from the database", ex);
            }
        }

        public async Task<List<Dog>> GetAllDogsAsync()
        {
            try
            {
                return await _realDatabase.Dogs.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while getting all dogs from the database", ex);
            }
        }

        public async Task<Dog> GetDogById(Guid dogId)
        {
            try
            {
                Dog? wantedDog = await _realDatabase.Dogs.FirstOrDefaultAsync(dog => dog.Id == dogId);

                if (wantedDog == null)
                {
                    throw new Exception($"There was no dog with Id {dogId} in the database");
                }

                return await Task.FromResult(wantedDog);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while getting a dog by Id {dogId} from database", ex);
            }
        }

        public Task<List<Dog>> GetDogsByWeightBreed(int? weight, string? breed)

        {
            throw new NotImplementedException();
        }

        public async Task<Dog> UpdateDog(Dog updatedDog)
        {
            try
            {
                _realDatabase.Dogs.Update(updatedDog);

                _realDatabase.SaveChanges();

                return await Task.FromResult(updatedDog);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while updating a dog by Id {updatedDog.Id} from database", ex);
            }
        }
    }
}
