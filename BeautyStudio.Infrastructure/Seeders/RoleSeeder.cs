using BeautyStudio.Domain.Entities;
using BeautyStudio.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
                var roleManager = new RoleStore<IdentityRole>(_dbContext);
                var existingRoles = await roleManager.Roles.ToListAsync();

                if (!existingRoles.Any())
                {
                    var roles = GetRoles();
                    foreach (var role in roles)
                        await roleManager.CreateAsync(role); 
                }
            }
        }

        private List<IdentityRole> GetRoles()
        {
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "Employee"
                },
                new IdentityRole()
                {
                    Name = "Owner"
                },
                new IdentityRole()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }
    }
}
