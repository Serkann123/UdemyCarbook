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
        public List<Blog> GetLast3BlogsWithAuthors();
    }
}
