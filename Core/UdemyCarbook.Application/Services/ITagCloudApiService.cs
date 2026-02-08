using UdemyCarbook.Dto.TagCloudDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ITagCloudApiService
    {
        Task<List<GetByBlogIdTagCloudDto>> GetByBlogIdAsync(int blogId);
    }
}
