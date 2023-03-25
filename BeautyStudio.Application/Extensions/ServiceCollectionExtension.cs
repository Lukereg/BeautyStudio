using BeautyStudio.Application.ApplicationUser;
using BeautyStudio.Application.BeautyStudio.Commands.CreateBeautyStudio;
using BeautyStudio.Application.MapProfiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
            services.AddMediatR(typeof(CreateBeautyStudioCommand));

            services.AddScoped<IUserContext, UserContext>();

            services.AddAutoMapper(typeof(BeautyStudioMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateBeautyStudioCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
