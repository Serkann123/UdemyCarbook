using UdemyCarbook.Dto.ServiceDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IServiceApiService
    {
        Task<List<ResultServiceDto>> GetAllAsync();
        Task<UpdateServiceDto?> GetByIdAsync(int id);
        Task<(bool ok, HttpResponseMessage? response)> CreateAsync(CreateServiceDto dto);
        Task<(bool ok, HttpResponseMessage? response)> UpdateAsync(UpdateServiceDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
