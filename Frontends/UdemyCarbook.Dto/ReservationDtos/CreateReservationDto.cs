using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Dto.ReservationDtos
{
        public class CreateReservationDto
        {
            [Required(ErrorMessage = "Ad zorunludur.")]
            [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
            public string? Name { get; set; }

            [Required(ErrorMessage = "Soyad zorunludur.")]
            [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
            public string? Surname { get; set; }

            [Required(ErrorMessage = "E-posta zorunludur.")]
            [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Telefon zorunludur.")]
            [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir.")]
            public string? Phone { get; set; }

            [Required(ErrorMessage = "Alış lokasyonu seçilmelidir.")]
            [Range(1, int.MaxValue, ErrorMessage = "Alış lokasyonu seçilmelidir.")]
            public int PickUpLocationId { get; set; }

            [Required(ErrorMessage = "Teslim lokasyonu seçilmelidir.")]
            [Range(1, int.MaxValue, ErrorMessage = "Teslim lokasyonu seçilmelidir.")]
            public int DropOffLocationId { get; set; }

            [Required(ErrorMessage = "Araç seçimi zorunludur.")]
            [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir araç seçiniz.")]
            public int CarId { get; set; }

            [Required(ErrorMessage = "Yaş zorunludur.")]
            [Range(18, 75, ErrorMessage = "Yaş 18 ile 75 arasında olmalıdır.")]
            public int Age { get; set; }

            [Required(ErrorMessage = "Ehliyet yılı zorunludur.")]
            [Range(1, 60, ErrorMessage = "Ehliyet yılı en az 1 olmalıdır.")]
            public int DriverLicenseYear { get; set; }

            [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
            public string? Description { get; set; }
    }
}
