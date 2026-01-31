using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsWithAuthorsAsync();
        Task<List<Blog>> GetBlogsAllWithAuthorsAsync();
        Task<List<Blog>> GetBlogByAuthorIdAsync(int id);
    }
}
