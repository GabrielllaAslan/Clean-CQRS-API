using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly IConfiguration _configuration;
        public UserRepository(RealDatabase animalDbContext, IConfiguration configuration)
        {
            _realDatabase = animalDbContext;
            _configuration = configuration;
        }

        public async Task<bool> AddUserAnimalAsync(UserAnimal userAnimal)
        {
            try
            {
                var user = await _realDatabase.Users.FirstOrDefaultAsync(u => u.Id == userAnimal.UserId);
                var animal = await _realDatabase.UserAnimals.FirstOrDefaultAsync(a => a.AnimalId == userAnimal.AnimalId);

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

        public User GetAllUsers(string userName, string password, CancellationToken cancellationToken)
        {
            var user = _realDatabase.Users.FirstOrDefault(u => u.UserName == userName);

            // Check if the user exists
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Verify the password by comparing the hashed input password with the stored hashed password
            if (!VerifyPasswordHash(password, user.Password))
            {
                throw new Exception("Invalid password");
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Use BCrypt to verify the password hash
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JWTToken:Token"]!);

          

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
   