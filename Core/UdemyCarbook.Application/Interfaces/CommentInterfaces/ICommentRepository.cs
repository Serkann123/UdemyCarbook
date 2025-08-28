using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CommentInterfaces
{
    public interface ICommentRepository
    {
        public List<Comment> GetCommentsByBlogId(int id);
        public int GetCountCommentBlog(int id);
    }
}
