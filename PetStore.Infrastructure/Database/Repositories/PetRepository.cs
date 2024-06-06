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

        public void Delete(Pet pet)
        {
            _context.Pets.Remove(pet);
        }

        public Task<List<Pet>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _context.Pets.ToListAsync(cancellationToken);
        }

        public Task<Pet?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return _context.Pets.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<Pet>> GetByBreedAsync(string breed, CancellationToken cancellationToken)
        {
            return _context.Pets.Where(x => x.Breed == breed).ToListAsync(cancellationToken);
        }

        public Task<bool> IsUniqueNameAsync(string name, CancellationToken cancellationToken)
        {
            return _context.Pets.AllAsync(x => x.Name != name, cancellationToken);
        }

        public void Update(Pet pet)
        {
            _context.Pets.Update(pet);
        }
    }
}
