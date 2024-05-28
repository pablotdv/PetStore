using Microsoft.EntityFrameworkCore;
using PetoStore.Domain.Pets;
using PetStore.Infrastructure.Database.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Infrastructure.Database
{
    public class PetStoreContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public PetStoreContext(DbContextOptions<PetStoreContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PetMapping());
        }
    }
}
