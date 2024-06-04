using PetoStore.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetoStore.Domain.Repositories
{
    public interface IPetRepository 
    {
        Task<Pet?> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Pet>> GetAllAsync(CancellationToken cancellationToken);
        Task<Pet> AddAsync(Pet pet, CancellationToken cancellationToken);
        void Update(Pet pet);
        void Delete(Pet pet);
        Task<List<Pet>> GetByBreedAsync(string breed, CancellationToken cancellationToken);
    }
}
