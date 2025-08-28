using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _context.Comments.Where(x => x.BlogId == id).ToList();
        }

        public int GetCountCommentBlog(int id)
        {
            return _context.Comments.Where(x=>x.BlogId==id).Count();
        }
    }
}
