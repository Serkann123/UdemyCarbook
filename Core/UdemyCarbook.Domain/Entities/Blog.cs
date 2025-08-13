using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Descrpiton { get; set; }
        public TagCloud TagCloud { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
