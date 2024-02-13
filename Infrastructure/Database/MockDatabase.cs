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
            new Dog { Id = Guid.NewGuid(), Name = "Milo", Weight = 15, Breed = "Labrador"},
            new Dog { Id = Guid.NewGuid(), Name = "Mila", Weight = 20, Breed = "Golden Retriever"},
            new Dog { Id = Guid.NewGuid(), Name = "Molly", Weight = 18, Breed = "German Shepherd"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests", Weight = 10, Breed = "Beagle"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345679"), Name = "AnotherTestDogForUnitTests", Weight = 22, Breed = "Dachshund"}
        };

        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Kolle", LikesToPlay = true, Weight = 4, Breed = "Siamese" },
            new Cat { Id = Guid.NewGuid(), Name = "Pelle", LikesToPlay = true, Weight = 6, Breed = "Persian" },
            new Cat { Id = Guid.NewGuid(), Name = "Mille", LikesToPlay = true, Weight = 5, Breed = "Maine Coon" },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345601"), Name = "TestCatForUnitTests", LikesToPlay = true, Weight = 3, Breed = "Tabby" },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345602"), Name = "AnotherTestCatForUnitTests", LikesToPlay = false, Weight = 5, Breed = "Bengal" }
        };

        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Lilly", CanFly = true, Color = "Blue" },
            new Bird { Id = Guid.NewGuid(), Name = "Ciccy", CanFly = true, Color = "Red" },
            new Bird { Id = Guid.NewGuid(), Name = "Illy", CanFly = false, Color = "Green" },
            new Bird { Id = Guid.NewGuid(), Name = "Sally", CanFly = true, Color = "Yellow" },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345603"), Name = "TestBirdForUnitTests", CanFly = true, Color = "Purple" },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345604"), Name = "AnotherTestBirdForUnitTests", CanFly = false, Color = "Orange" }
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
