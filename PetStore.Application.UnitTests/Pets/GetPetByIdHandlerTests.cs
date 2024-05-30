using Moq;
using PetoStore.Domain.Pets;
using PetoStore.Domain.Repositories;
using PetStore.Application.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.UnitTests.Pets
{
    public class GetPetByIdHandlerTests 
    {
        private readonly GetPetByIdHandler _handler;
        private readonly Mock<IPetRepository> _petRepositoryMock;

        public GetPetByIdHandlerTests()
        {
            _petRepositoryMock = new Mock<IPetRepository>();
            _handler = new GetPetByIdHandler(_petRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_NotFoundResponse_When_Pet_NotFound()
        {
            // Arrange
            var request = new GetPetByIdRequest
            {
                Id = Guid.NewGuid()
            };
            _petRepositoryMock.Setup(x => x.GetAsync(request.Id)).ReturnsAsync((Pet)null);

            // Act
            var response = await _handler.Handle(request, default);

            // Assert
            Assert.IsType<NotFoundResponse>(response);
        }

        [Fact]
        public async Task Handle_Should_Return_GetPetByIdResponse_When_Pet_Found()
        {
            // Arrange
            var request = new GetPetByIdRequest
            {
                Id = Guid.NewGuid()
            };
            var pet = new Pet
            {
                Id = request.Id,
                Name = "Fluffy",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };
            _petRepositoryMock.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(pet);

            // Act
            var response = await _handler.Handle(request, default);

            // Assert
            Assert.IsType<GetPetByIdResponse>(response);
            var getPetByIdResponse = response as GetPetByIdResponse;
            Assert.Equal(pet.Id, getPetByIdResponse.Id);
            Assert.Equal(pet.Name, getPetByIdResponse.Name);
            Assert.Equal(pet.Breed, getPetByIdResponse.Breed);
            Assert.Equal(pet.Color, getPetByIdResponse.Color);
            Assert.Equal(pet.DateOfBirth, getPetByIdResponse.DateOfBirth);
            Assert.Equal(pet.Description, getPetByIdResponse.Description);
        }
    }
}
