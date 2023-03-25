using AutoMapper;
using BeautyStudio.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public BeautyStudioService(IBeautyStudioRepository beautyStudioRepository, IMapper mapper, IUserContext userContext)
        {
            _beautyStudioRepository = beautyStudioRepository;
            _mapper = mapper;
            _userContext = userContext; 
        }

        public async Task Create(AddBeautyStudioDto beautyStudioDto)
        {
            var beautyStudio = _mapper.Map<Domain.Entities.BeautyStudio>(beautyStudioDto);
            beautyStudio.OwnerId = _userContext.GetCurrentUser().Id;

            beautyStudio.EncodeName();

            await _beautyStudioRepository.Create(beautyStudio);
        }

        public async Task<IEnumerable<GetBeuatyStudioDto>> GetAll()
        {
            var beautyStudios = await _beautyStudioRepository.GetAll();
            var result = _mapper.Map<IEnumerable<GetBeuatyStudioDto>>(beautyStudios);

            return result;
        }
    }
}
