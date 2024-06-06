using Microsoft.EntityFrameworkCore;
using PetStore.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace PetStore.Infrastructure.UnitTests
{
    public class RepositoryBaseTests
    {
        protected readonly PetStoreContext _context;
        protected readonly string _instanceId;
        protected readonly ITestOutputHelper _output;
        public RepositoryBaseTests(ITestOutputHelper output)
        {
            var options = new DbContextOptionsBuilder<PetStoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .LogTo(output.WriteLine)
                .Options;
            _context = new(options);
            _context = new PetStoreContext(options);
            _instanceId = Guid.NewGuid().ToString();
            _output = output;
        }
    }
}
