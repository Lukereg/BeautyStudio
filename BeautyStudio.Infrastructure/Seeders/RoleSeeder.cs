using BeautyStudio.Domain.Entities;
using BeautyStudio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Infrastructure.Seeders
{
    public class RoleSeeder
    {
        private readonly BeautyStudioDbContext _dbContext;
    
        public RoleSeeder(BeautyStudioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    await _dbContext.Roles.AddRangeAsync(roles);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Employee"
                },
                new Role()
                {
                    Name = "Owner"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }
    }
}
