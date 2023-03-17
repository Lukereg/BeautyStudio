using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? Description { get; set; }

        public List<Visit> Visits { get; set; } = new();
        public BeautyStudio BeautyStudio { get; set; } = default!;
        public int BeautyStudioId { get; set; }
     }
}
