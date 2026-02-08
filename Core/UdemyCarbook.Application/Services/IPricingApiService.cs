using UdemyCarbook.Dto.PirincingDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IPricingApiService
    {
        Task<List<ResultPricingDto>> GetAllAsync();
        Task<UpdatePrincingDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreatePrincingDto dto);
        Task<bool> UpdateAsync(UpdatePrincingDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
