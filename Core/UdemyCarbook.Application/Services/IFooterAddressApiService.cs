using UdemyCarbook.Dto.FooterAdressDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IFooterAddressApiService
    {
        Task<List<ResultFeatureAddressDto>> GetAllAsync();
        Task<UpdateFooterAddressDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateFooterAddressDto dto);
        Task<bool> UpdateAsync(UpdateFooterAddressDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
