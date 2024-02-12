using Domain.Models;
using Infrastructure.Database;

namespace Application.Commands.Birds.AddBird.Tests
{
    [TestFixture]
    public class AddBirdCommandHandlerTests
    {
        private Mock<MockDatabase> _mockDatabase;
        private AddBirdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new Mock<MockDatabase>();
            _handler = new AddBirdCommandHandler(_mockDatabase.Object);
        }

        [Test]
        public async Task Handle_ValidCommand_AddsBirdToDatabase()
        {
            // Arrange
            var command = new AddBirdCommand
            {
                NewBird = new Bird
                {
                    Name = "Eagle",
                    CanFly = true
                }
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(command.NewBird.Name, result.Name);
            Assert.AreEqual(command.NewBird.CanFly, result.CanFly);
            _mockDatabase.Verify(db => db.Birds.Add(It.IsAny<Bird>()), Times.Once);
        }
    }
}
