using BeautyStudio.Application.Models.BeautyStudio;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Application.MapProfiles
{
    public class BeautyStudioMappingProfile : Profile
    {
        public BeautyStudioMappingProfile()
        {
            CreateMap<AddBeautyStudioDto, Domain.Entities.BeautyStudio>();
            CreateMap<Domain.Entities.BeautyStudio, GetBeuatyStudioDto>();
        }
    }
}
