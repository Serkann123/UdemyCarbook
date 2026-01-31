using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Dto.CarDtos
{
    public class ResultCarForReservationDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Model { get; set; } = null!;
    }
}
