using PetoStore.Domain.Pets;
using PetoStore.Domain.Repositories;
using PetStore.Infrastructure.Database.Repositories;
using Xunit.Abstractions;

namespace PetStore.Infrastructure.UnitTests.Repositories
{
    public class PetRepositoryTests : RepositoryBaseTests
    {
        private readonly IPetRepository _petRepository;

        public PetRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _petRepository = new PetRepository(_context);
            _output.WriteLine($"Instance ID: {_instanceId}");
        }

        [Fact]
        public async Task IsUniqueNameAsync_Should_Return_True_When_Name_Is_Unique()
        {
            // Arrange
            var name = "Fluffy";
            await _context.Pets.AddAsync(new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Fido",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            });
            await _context.Pets.AddAsync(new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Spot",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _petRepository.IsUniqueNameAsync(name, default);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsUniqueNameAsync_Should_Return_False_When_Name_Is_Not_Unique()
        {
            // Arrange
            var name = "Fluffy";
            await _context.Pets.AddAsync(new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Fluffy",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            });
            await _context.Pets.AddAsync(new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Spot",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _petRepository.IsUniqueNameAsync(name, default);

            // Assert
            Assert.False(result);
        }
    }
}
