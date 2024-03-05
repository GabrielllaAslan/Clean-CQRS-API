using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.BirdRepository
{
    public class BirdRepository : IBirdRepository
    {
        private readonly RealDatabase _realDatabase;

        public BirdRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Bird> AddBird(Bird newbird, CancellationToken cancellationToken)
        {
            _realDatabase.Birds.Add(newbird);
            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(newbird);

        }

        public Task<Bird> DeleteBird(Guid? id, CancellationToken cancellationToken)
        {
            var birdToDelete = _realDatabase.Birds.FirstOrDefault(b => b.Id == id);

            _realDatabase.Remove(birdToDelete!);
            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(birdToDelete!);

        }

        public Task<List<Bird>> GetAllBirdsAsync(CancellationToken cancellationToken)
        {
            List<Bird> allBirds = _realDatabase.Birds.ToList();

            return Task.FromResult(allBirds);
        }

        public Task<List<Bird>> GetAllBirdsByColor(string color, CancellationToken cancellationToken)
        {
            List<Bird> filterBirdByColor = _realDatabase.Birds.Where(b =>  b.Color == color).ToList();

            return Task.FromResult(filterBirdByColor);
        }

        public Task<Bird> GetBirdById(Guid id, CancellationToken cancellationToken)
        {
            Bird wantedBird = _realDatabase.Birds.FirstOrDefault(b => b.Id == id);

            return Task.FromResult(wantedBird!);
        }

        public Task<Bird> UpdateBird(Guid id, string newName, string color, bool CanFly, CancellationToken cancellationToken)
        {
            Bird BirdUpdate = _realDatabase.Birds.FirstOrDefault(b => b.Id == id);

            BirdUpdate.Name = newName;
            BirdUpdate.Color = color;
            BirdUpdate.CanFly = CanFly;

            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(BirdUpdate);
        }
    }
}
