using Microsoft.EntityFrameworkCore;
using PetoStore.Domain.Pets;
using PetoStore.Domain.Repositories;
using PetStore.Infrastructure.Database;
using PetStore.Infrastructure.Database.Repositories;
using Xunit.Abstractions;

namespace PetStore.Infrastructure.UnitTests.Repositories
{
    public class PetRepositoryGetAsyncTests : RepositoryBaseTests
    { 
        private readonly IPetRepository _petRepository;
        
        public PetRepositoryGetAsyncTests(ITestOutputHelper output) : base(output)
        {   
            _petRepository = new PetRepository(_context);
            _output.WriteLine($"Instance ID: {_instanceId}");
        }

        [Fact]
        public async Task GetAsync_Should_Return_Pet_When_Found()
        {
            // Arrange
            var pet1 = new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Fluffy",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };
            var pet2 = new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Spot",
                Breed = "Dalmatian",
                Color = "Black and White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A black and white dalmatian"
            };
            var pet3 = new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Rover",
                Breed = "Golden Retriever",
                Color = "Golden",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A golden retriever"
            };
            await _petRepository.AddAsync(pet1, default);
            await _petRepository.AddAsync(pet2, default);
            await _petRepository.AddAsync(pet3, default);
            await _context.SaveChangesAsync();

            // Act
            var result = await _petRepository.GetAsync(pet2.Id, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pet2, result);
        }
    }
}
