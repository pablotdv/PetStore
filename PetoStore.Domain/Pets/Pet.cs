using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetoStore.Domain.Pets
{   
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
    }
}
