using BeautyStudio.Domain.Interfaces;
using BeautyStudio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Infrastructure.Repositories
{
    public class BeautyStudioRepository : IBeautyStudioRepository
    {

        private readonly BeautyStudioDbContext _dbContext;

        public BeautyStudioRepository(BeautyStudioDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.BeautyStudio beautyStudio)
        {
            await _dbContext.AddAsync(beautyStudio);
            await _dbContext.SaveChangesAsync();
        }
    }
}
