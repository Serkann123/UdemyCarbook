using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
         List<Blog> GetLast3BlogsWithAuthors();
         List<Blog> GetBlogsAllWithAuthors();
        List<Blog> GetBlogByAuthorId(int id);
    }
}
