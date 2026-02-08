
using UdemyCarbook.Dto.AboutDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IAboutApiService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task<UpdateAboutDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateAboutDto dto);
        Task<bool> UpdateAsync(UpdateAboutDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
