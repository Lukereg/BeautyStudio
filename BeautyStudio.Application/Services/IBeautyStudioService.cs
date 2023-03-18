using BeautyStudio.Application.Models.BeautyStudio;

namespace BeautyStudio.Application.Services
{
    public interface IBeautyStudioService
    {
        Task Create(AddBeautyStudioDto beautyStudioDto);
    }
}