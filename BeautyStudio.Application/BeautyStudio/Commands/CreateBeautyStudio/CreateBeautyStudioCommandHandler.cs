using AutoMapper;
using BeautyStudio.Application.ApplicationUser;
using BeautyStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Application.BeautyStudio.Commands.CreateBeautyStudio
{
    public class CreateBeautyStudioCommandHandler : IRequestHandler<CreateBeautyStudioCommand>
    {
        private readonly IBeautyStudioRepository _beautyStudioRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateBeautyStudioCommandHandler(IBeautyStudioRepository beautyStudioRepository, IMapper mapper, IUserContext userContext)
        {
            _beautyStudioRepository = beautyStudioRepository;
            _mapper = mapper;
            _userContext = userContext;
        }   

        public async Task<Unit> Handle(CreateBeautyStudioCommand request, CancellationToken cancellationToken)
        {
            var beautyStudio = _mapper.Map<Domain.Entities.BeautyStudio>(request);
            beautyStudio.OwnerId = _userContext.GetCurrentUser().Id;
            beautyStudio.EncodeName();

            await _beautyStudioRepository.Create(beautyStudio);

            return Unit.Value;
        }
    }
}
