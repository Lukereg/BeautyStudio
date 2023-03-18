using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Domain.Entities
{
    public class BeautyStudio
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string EncodedName { get; private set; } = default!;

        public List<Visit> Visits { get; set; } = new();
        public List<User> Employees { get; set; } = new();
        public List<Client> Clients { get; set; } = new();
        public User Owner { get; set; } = default!;
        public int OwnerId { get; set; }

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
        
    }
}
