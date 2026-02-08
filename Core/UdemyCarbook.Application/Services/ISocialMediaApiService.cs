using UdemyCarbook.Dto.SocialMediaDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ISocialMediaApiService
    {
        Task<List<ResultSocialMediaDto>> GetAllAsync();
        Task<UpdateSocialMediaDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateSocialMediaDto dto);
        Task<bool> UpdateAsync(UpdateSocialMediaDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
