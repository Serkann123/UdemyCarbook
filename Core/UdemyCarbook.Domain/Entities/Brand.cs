﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Domain.Entities
{
    public class Brand
    {
        [Key]
        public int BranId { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
