
using UdemyCarbook.Dto.AuthorDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IAuthorApiService
    {
        Task<List<ResultAuthorDto>> GetAllAsync();
        Task<UpdateAuthorDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateAuthorDto dto);
        Task<bool> UpdateAsync(UpdateAuthorDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
