using Application.Commands.Dogs.DeleteDog;
using Infrastructure.Database;
using System.Reflection.Metadata;

namespace Test.DogTests.CommandTest.DeleteDog
{
    [TestFixture]
    public class DeleteDogTest
    {
        private MockDatabase _database;
        private DeleteDogByIdCommandHandler _command;
        private object _handler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _database = new MockDatabase();
            _command = new DeleteDogByIdCommandHandler(_database);
        }
    }
}