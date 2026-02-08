using UdemyCarbook.Dto.CategoryDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ICategoryApiService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task<UpdateCategoryDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCategoryDto dto);
        Task<bool> UpdateAsync(UpdateCategoryDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
