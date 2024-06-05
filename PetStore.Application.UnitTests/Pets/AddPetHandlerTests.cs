using Moq;
using PetoStore.Domain.Pets;
using PetoStore.Domain.Repositories;
using PetStore.Application.Pets.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.UnitTests.Pets
{
    public class AddPetHandlerTests
    {
        private readonly AddPetHandler _handler;
        private readonly Mock<IPetRepository> _petRepositoryMock;
        public AddPetHandlerTests()
        {
            _petRepositoryMock = new Mock<IPetRepository>();
            _handler = new AddPetHandler(_petRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Add_Pet()
        {
            // Arrange
            var request = new AddPetRequest
            {
                Name = "Fluffy",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };

            // Act
            var response = await _handler.Handle(request, default);

            // Assert
            _petRepositoryMock.Verify(x => x.AddAsync(It.Is<Pet>(p =>
                p.Name == request.Name &&
                p.Breed == request.Breed &&
                p.Color == request.Color &&
                p.DateOfBirth == request.DateOfBirth &&
                p.Description == request.Description), default));
        }


    }
}
