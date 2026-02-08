using FluentValidation;
using UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands;

namespace UdemyCarbook.Application.Validators.Reservation
{
    public class UpdateReservationValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationValidator()
        {
            RuleFor(x => x.ReservationId)
               .GreaterThan(0).WithMessage("Geçersiz rezervasyon.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad zorunludur.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad zorunludur.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta giriniz.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon zorunludur.")
                .MaximumLength(20).WithMessage("Telefon numarası çok uzun.");

            RuleFor(x => x.CarId)
                .GreaterThan(0).WithMessage("Araç seçimi zorunludur.");

            RuleFor(x => x.PickUpLocationId)
                .NotNull().WithMessage("Alış lokasyonu seçilmelidir.");

            RuleFor(x => x.DropOffLocationId)
                .NotNull().WithMessage("Teslim lokasyonu seçilmelidir.");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(18).WithMessage("Yaş 18 veya üzeri olmalıdır.")
                .LessThanOrEqualTo(75).WithMessage("Yaş geçerli değil.");

            RuleFor(x => x.DriverLicenseYear)
                .GreaterThanOrEqualTo(1).WithMessage("Ehliyet yılı en az 1 yıl olmalıdır.")
                .LessThanOrEqualTo(60).WithMessage("Ehliyet yılı geçerli değil.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.PickUpDateTime)
                .NotEmpty().WithMessage("Alış tarih/saat zorunludur.");

            RuleFor(x => x.DropOffDateTime)
                .NotEmpty().WithMessage("Teslim tarih/saat zorunludur.");

            RuleFor(x => x)
                .Must(x => x.DropOffDateTime > x.PickUpDateTime)
                .WithMessage("Teslim tarihi, alış tarihinden sonra olmalıdır.");
        }
    }
}
