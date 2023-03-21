﻿using BeautyStudio.Domain.Interfaces;
using BeautyStudio.Infrastructure.Persistence;
using BeautyStudio.Infrastructure.Repositories;
using BeautyStudio.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BeautyStudioDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("BeautyStudio")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<BeautyStudioDbContext>();

            services.AddScoped<RoleSeeder>();

            services.AddScoped<IBeautyStudioRepository, BeautyStudioRepository>();
        }
    }
}
