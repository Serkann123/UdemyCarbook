using UdemyCarbook.Dto.BannerDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IBannerApiService
    {
        Task<List<ResultBannerDto>> GetAllAsync();
        Task<UpdateBannerDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateBannerDto dto);
        Task<bool> UpdateAsync(UpdateBannerDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
