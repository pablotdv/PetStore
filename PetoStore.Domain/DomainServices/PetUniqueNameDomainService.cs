using PetoStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetoStore.Domain.DomainServices
{
    public class PetUniqueNameDomainService
    {
        private readonly IPetRepository _petRepository;

        public PetUniqueNameDomainService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Task IsUniqueNameAsync(string name)
        {
            return _petRepository.IsUniqueNameAsync(name, default);
        }
    }
}
