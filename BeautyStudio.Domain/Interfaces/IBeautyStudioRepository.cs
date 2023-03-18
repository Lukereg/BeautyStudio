using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Domain.Interfaces
{
    public interface IBeautyStudioRepository
    {
        Task Create(Domain.Entities.BeautyStudio beautyStudio);
    }
}
