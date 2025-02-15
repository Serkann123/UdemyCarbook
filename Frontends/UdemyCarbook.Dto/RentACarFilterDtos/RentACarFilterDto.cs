using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Dto.RentACarFilterDtos
{
    public class RentACarFilterDto
    {
        public int locationId { get; set; }
        public bool available { get; set; }
    }
}
