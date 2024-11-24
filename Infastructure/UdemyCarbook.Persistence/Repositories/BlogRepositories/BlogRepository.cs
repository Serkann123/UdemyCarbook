using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.AuthorId).Take(3).ToList();
            return values;
        }
    }
}
