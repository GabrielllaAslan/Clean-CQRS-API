using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Milo", },
            new Dog { Id = Guid.NewGuid(), Name = "Mila", },
            new Dog { Id = Guid.NewGuid(), Name = "Molly", },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678") },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345679") }
        };

        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Kolle", },
            new Cat { Id = Guid.NewGuid(), Name = "Pelle", },
            new Cat { Id = Guid.NewGuid(), Name = "Mille", },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345601"), },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345602"), }
        };

        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Lilly", CanFly = true, },
            new Bird { Id = Guid.NewGuid(), Name = "Ciccy", CanFly = true, },
            new Bird { Id = Guid.NewGuid(), Name = "Illy", CanFly = false, },
            new Bird { Id = Guid.NewGuid(), Name = "Sally", CanFly = true, },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345603"), Name = "TestBirdForUnitTests", CanFly = true, },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345604"), Name = "AnotherTestBirdForUnitTests", CanFly = false, }
        };

        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<User> allUsers = new()
        {
            new User { Id = Guid.NewGuid(), UserName = "Gabbi"},
            new User { Id = Guid.NewGuid(), UserName = "Gabbe"},
            new User { Id = Guid.NewGuid(), UserName = "Lina"},
            new User { Id = new Guid("550e8400-e29b-41d4-a716-446655440000"), UserName = "TestUserForUnitTests"}

        };

    }
}
