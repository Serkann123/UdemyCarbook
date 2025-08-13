using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
