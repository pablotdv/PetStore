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
        Task<Pet?> GetAsync(Guid id);
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<Pet> AddAsync(Pet pet, CancellationToken cancellationToken);
        Task UpdateAsync(Pet pet);
        Task DeleteAsync(Pet pet);
        Task<IEnumerable<Pet>> GetByBreedAsync(string breed);
    }
}
