using System.ComponentModel.DataAnnotations;

namespace UdemyCarbook.Dto.ServiceDtos
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        [StringLength(50, ErrorMessage = "Başlık en fazla 50 karakter olmalıdır.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(200, ErrorMessage = "Açıklama en fazla 200 karakter olmalıdır.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Icon URL zorunludur.")]
        [StringLength(250, ErrorMessage = "Icon URL en fazla 250 karakter olmalıdır.")]
        public string? IconUrl { get; set; }
    }
}
