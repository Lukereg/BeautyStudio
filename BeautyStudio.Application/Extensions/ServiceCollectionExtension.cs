﻿using BeautyStudio.Application.ApplicationUser;
using BeautyStudio.Application.MapProfiles;
using BeautyStudio.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBeautyStudioService, BeautyStudioService>();
            services.AddScoped<IUserContext, UserContext>();

            services.AddAutoMapper(typeof(BeautyStudioMappingProfile));
        }
    }
}
