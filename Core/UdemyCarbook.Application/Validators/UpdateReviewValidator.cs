using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.ReviewCommands;

namespace UdemyCarbook.Application.Validators
{
    public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator() 
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girşi yapınız");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmın en az 50 karakter giriniz");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen yorum kısmın en fazla 500 karakter giriniz");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen müşteri resmini boş geçmeyiniz").MinimumLength(10)
            .WithMessage("Lütfen en az 10 karakter veri girişi yapınız");
        }
    }
}
