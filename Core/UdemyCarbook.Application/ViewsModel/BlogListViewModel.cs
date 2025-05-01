using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Dto.BlogDtos;

namespace UdemyCarbook.Application.ViewsModel
{
    public class BlogListViewModel
    {
        public List<ResultBlogsAllWithAuthor> Blogs { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
