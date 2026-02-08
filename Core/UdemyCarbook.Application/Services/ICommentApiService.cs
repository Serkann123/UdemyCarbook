using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ICommentApiService
    {

        Task<List<ResultCommentDto>> GetAllAsync();
        Task<List<ResultCommentDto>> GetByBlogIdAsync(int id);
        Task<bool> CreateAsync(CreateCommentDto dto);
        Task<bool> RemoveAsync(int id);
        Task<CommentCountDto?> GetCountByBlogIdAsync(int blogId);
    }
}
