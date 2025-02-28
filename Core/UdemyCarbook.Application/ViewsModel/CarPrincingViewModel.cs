using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.ViewsModel
{
    public class CarPrincingViewModel
    {
        public CarPrincingViewModel()
        {
            Amounts = new List<Decimal>();
        }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public List<Decimal> Amounts { get; set; }
    }
}
