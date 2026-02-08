using UdemyCarbook.Dto.FeatureDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IFeatureApiService
    {
        Task<List<ResultFeatureDto>> GetAllAsync();
        Task<UpdateFeatureDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateFeatureDto dto);
        Task<bool> UpdateAsync(UpdateFeatureDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
