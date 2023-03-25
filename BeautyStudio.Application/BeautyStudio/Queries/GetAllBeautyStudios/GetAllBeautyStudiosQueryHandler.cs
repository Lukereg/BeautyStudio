using AutoMapper;
using BeautyStudio.Application.ApplicationUser;
using BeautyStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Application.BeautyStudio.Queries.GetAllBeautyStudios
{
    public class GetAllBeautyStudiosQueryHandler : IRequestHandler<GetAllBeautyStudiosQuery, IEnumerable<GetBeuatyStudioDto>>
    {
        private readonly IBeautyStudioRepository _beautyStudioRepository;
        private readonly IMapper _mapper;

        public GetAllBeautyStudiosQueryHandler(IBeautyStudioRepository beautyStudioRepository, IMapper mapper)
        {
            _beautyStudioRepository = beautyStudioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBeuatyStudioDto>> Handle(GetAllBeautyStudiosQuery request, CancellationToken cancellationToken)
        {
            var beautyStudios = await _beautyStudioRepository.GetAll();
            var result = _mapper.Map<IEnumerable<GetBeuatyStudioDto>>(beautyStudios);

            return result;
        }
    }
}
