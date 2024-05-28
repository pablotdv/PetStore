using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PetoStore.Domain.Pets;
using PetoStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Infrastructure.Database.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetStoreContext _context;

        public PetRepository(PetStoreContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddAsync(Pet pet, CancellationToken cancellationToken)
        {
            var result = await _context.Pets.AddAsync(pet, cancellationToken);
            return result.Entity;
        }

        public Task DeleteAsync(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pet>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pet?> GetAsync(Guid id)
        {
            return _context.Pets.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public Task<IEnumerable<Pet>> GetByBreedAsync(string breed)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
