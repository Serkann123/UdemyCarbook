using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.BlogInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository:IBlogRepository
    {
        private readonly CarbookContext _context;

        public BlogRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetBlogByAuthorIdAsync(int id)
        {
            var values = await _context.Blogs.Include(x => x.Author).Where(y => y.BlogId == id).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetBlogsAllWithAuthorsAsync()
        {
            var values = await _context.Blogs.Include(x => x.Author).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthorsAsync()
        {
            var values = await _context.Blogs.Include(x => x.Author).
                OrderByDescending(x => x.AuthorId).Take(3).ToListAsync();
            return values;
        }
    }
}
