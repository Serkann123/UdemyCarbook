using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository: ITagCloudRepository
    {
        private readonly CarbookContext _context;

        public TagCloudRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudByBlogIdAsync(int id)
        {
            return await _context.TagClouds.Where(x => x.BlogId == id).ToListAsync();
        }
    }
}
