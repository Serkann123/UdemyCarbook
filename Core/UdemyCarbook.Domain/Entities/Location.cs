using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Domain.Entities
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public List<RendACar> rendACars { get; set; }
        public List<Reservation> PickUpReservations { get; set; }
        public List<Reservation> DropOffReservations { get; set; }
    }
}
