using UdemyCarbook.Dto.LocationDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ILocationApiService
    {
        Task<List<ResultLocationDto>> GetAllAsync();
        Task<UpdateLocationDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateLocationDto dto);
        Task<bool> UpdateAsync(UpdateLocationDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
