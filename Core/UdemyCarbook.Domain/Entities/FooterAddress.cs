﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Domain.Entities
{
    public class FooterAddress
    {
        [Key]
        public int FooterAddressId { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
    }
}
