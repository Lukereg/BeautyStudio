using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyStudio.Application.BeautyStudio.Queries;
using BeautyStudio.Application.BeautyStudio.Commands.CreateBeautyStudio;

namespace BeautyStudio.Application.MapProfiles
{
    public class BeautyStudioMappingProfile : Profile
    {
        public BeautyStudioMappingProfile()
        {
            CreateMap<CreateBeautyStudioDto, Domain.Entities.BeautyStudio>();
            CreateMap<Domain.Entities.BeautyStudio, GetBeuatyStudioDto>();
        }
    }
}
