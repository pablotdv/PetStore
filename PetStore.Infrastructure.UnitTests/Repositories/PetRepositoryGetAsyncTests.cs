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
        }

        [Fact]
        public async Task GetAsync_Should_Return_Pet_When_Found()
        {
            // Arrange
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Fluffy",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };
            await _petRepository.AddAsync(pet, default);
            await _context.SaveChangesAsync();

            // Act
            var result = await _petRepository.GetAsync(pet.Id, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pet, result);
        }
    }
}
