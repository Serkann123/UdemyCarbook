using UdemyCarbook.Dto.AuthorDtos;
using UdemyCarbook.Dto.BlogDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IBlogApiService
    {
        Task<List<ResultBlogsAllWithAuthorDto>> GetBlogsAllWithAuthorsAsync();
        Task<bool> RemoveAsync(int id);
        Task<GetBlogByIdDto?> GetByIdAsync(int id);
        Task<List<ResultBlog3WithBrandsAuthorsDto>> GetLast3WithAuthorsAsync();
        Task<List<ResultBlogByAuthorIdDto>> GetByAuthorIdAsync(int authorId);
    }
}
