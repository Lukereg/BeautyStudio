using AutoMapper;
using BeautyStudio.Application.Models.BeautyStudio;
using BeautyStudio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Application.Services
{
    public class BeautyStudioService : IBeautyStudioService
    {
        private readonly IBeautyStudioRepository _beautyStudioRepository;
        private readonly IMapper _mapper;

        public BeautyStudioService(IBeautyStudioRepository beautyStudioRepository, IMapper mapper)
        {
            _beautyStudioRepository = beautyStudioRepository;
            _mapper = mapper;
        }

        public async Task Create(AddBeautyStudioDto beautyStudioDto)
        {
            var beautyStudio = _mapper.Map<Domain.Entities.BeautyStudio>(beautyStudioDto);

            beautyStudio.EncodeName();

            await _beautyStudioRepository.Create(beautyStudio);
        }
    }
}
