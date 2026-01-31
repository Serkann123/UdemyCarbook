using System.Data.Entity;
using UdemyCarbook.Application.Interfaces.CommentInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarbookContext _context;

        public CommentRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentsByBlogIdAsync(int id)
        {
            return await _context.Comments.Where(x => x.BlogId == id).ToListAsync();
        }

        public async Task<int> GetCountCommentBlogAsync(int id)
        {
            return await _context.Comments.Where(x => x.BlogId == id).CountAsync();
        }
    }
}
