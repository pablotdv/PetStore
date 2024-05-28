﻿using Microsoft.EntityFrameworkCore;
using PetoStore.Domain.Pets;
using PetoStore.Domain.Repositories;
using PetStore.Infrastructure.Database;
using PetStore.Infrastructure.Database.Repositories;

namespace PetStore.Infrastructure.Tests.Repositories
{
    public class PetRepositoryTests
    {
        private readonly IPetRepository _petRepository;
        private readonly PetStoreContext _context;

        public PetRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<PetStoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())                
                .Options;
            _context = new(options);
            _petRepository = new PetRepository(_context);
        }

        [Fact]
        public async Task AddAsync_Should_Save_ToDatabase()
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

            // Act
            await _petRepository.AddAsync(pet, default);
            await _context.SaveChangesAsync();

            // Assert
            var addedPet = await _petRepository.GetAsync(pet.Id);
            Assert.NotNull(addedPet);
            Assert.Equal(pet, addedPet);
        }

        [Fact]
        public async Task AddAsync_Should_ThrowError_When_Name_Null()
        {
            // Arrange
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = null,
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };

            // Act
            await _petRepository.AddAsync(pet, default);

            // Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => _context.SaveChangesAsync());            
        }

        [Fact]
        public async Task AddAsync_Should_ThrowError_When_Breed_Null()
        {
            // Arrange
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = "Fluffy",
                Breed = null,
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };

            // Act
            await _petRepository.AddAsync(pet, default);

            // Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => _context.SaveChangesAsync());
        }
    }
}
