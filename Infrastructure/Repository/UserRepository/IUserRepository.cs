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
        User GetAllUsers(string userName, string password, CancellationToken cancellationToken);
        string GenerateJwtToken(User user);
        Task SaveChangesAsync();
        Task AddUserAsync(User user);
        Task<bool> AddUserAnimalAsync(UserAnimal userAnimal);

    }
}
