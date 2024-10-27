using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Domain.Entities
{
    public class CarPricing
    {
        [Key]
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PiricingId { get; set; }
        public Piricing Piricing { get; set; }
        public decimal Ammount { get; set; }
    }
}
