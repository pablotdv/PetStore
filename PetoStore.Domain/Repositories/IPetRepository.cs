using PetoStore.Domain.Pets;

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
        Task<bool> IsUniqueNameAsync(string name, CancellationToken cancellationToken);
    }
}
