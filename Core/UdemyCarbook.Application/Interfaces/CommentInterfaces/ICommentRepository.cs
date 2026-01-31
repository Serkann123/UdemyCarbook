using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CommentInterfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsByBlogIdAsync(int id);
        Task<int> GetCountCommentBlogAsync(int id);
    }
}
