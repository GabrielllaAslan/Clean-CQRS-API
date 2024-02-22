using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Repository.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.AnimalToUser
{
    public class AddNewAnimalCommandHandler : IRequestHandler<AddNewAnimalCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public AddNewAnimalCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AddNewAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newAnimalDto = request.NewAnimalToUser;

                var userAnimal = new UserAnimal
                {
                    UserId = newAnimalDto.UserId,
                    AnimalId = newAnimalDto.AnimalId,
                };

                return await _userRepository.AddUserAnimalAsync(userAnimal);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddUserAnimalAsync(UserAnimal userAnimal)
        {
            try
            {
                // Assuming UserAnimal has a corresponding DbSet in your DbContext
                _userRepository.UserAnimals.Add(userAnimal);

                // Save changes to the database
                await _userRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return false;
            }
        }
    }
}
