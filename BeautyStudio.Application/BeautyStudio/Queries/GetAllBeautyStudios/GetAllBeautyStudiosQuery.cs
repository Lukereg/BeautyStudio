using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Application.BeautyStudio.Queries.GetAllBeautyStudios
{
    public class GetAllBeautyStudiosQuery : IRequest<IEnumerable<GetBeuatyStudioDto>>
    {
    }
}
