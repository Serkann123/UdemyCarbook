using UdemyCarbook.Dto.ContactDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IContactApiService
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task<bool> RemoveAsync(int id);
        Task<bool> CreateAsync(CreateContactDto dto);
    }
}
