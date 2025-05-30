﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Dto.BlogDtos
{
    public class ResultBlog3WithBrandsAuthorsDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryId { get; set; }
        public string AuthorName { get; set; }
    }
}
