using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.ServiceCommands;

namespace UdemyCarbook.Application.Validators.Service
{
    public class UpdateServiceValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık zorunludur.")
                .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama zorunludur.")
                .MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olmalıdır.");

            RuleFor(x => x.IconUrl).NotEmpty().WithMessage("Icon URL zorunludur.")
           .MaximumLength(250).WithMessage("Icon URL en fazla 250 karakter olmalıdır.");
        }
    }
}
