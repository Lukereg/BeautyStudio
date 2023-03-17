using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public List<Role> Roles { get; set; } = new();
        public List<BeautyStudio> StudiosWhereWorks { get; set; } = new();
        public List<BeautyStudio> OwnStudios { get; set; } = new();
        public List<Visit> AssignedVisits { get; set; } = new();


    }
}
