using UdemyCarbook.Dto.TestimonialDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ITestimonialApiService
    {
        Task<List<ResultTestimonialDto>> GetAllAsync();
        Task<UpdateTestimonialDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateTestimonialDto dto);
        Task<bool> UpdateAsync(UpdateTestimonialDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
