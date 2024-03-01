using Domain.Models;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UserRepository
{
    public interface IUserRepository

    {
        Task<List<User>> GetAllUsers(string userName, CancellationToken cancellationToken);
        Task SaveChangesAsync();
        Task AddUserAsync(User user);
        Task<bool> AddUserAnimalAsync(UserAnimal userAnimal);

    }
}
