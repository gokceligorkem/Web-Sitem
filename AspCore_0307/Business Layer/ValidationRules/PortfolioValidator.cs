using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez.");
            RuleFor(x => x.ImgUrl).NotEmpty().WithMessage("Görsel alanını boş geçilemez");
            RuleFor(x => x.SlidUrl).NotEmpty().WithMessage("Slide alanını boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Lütfen Ücret alanını boş geçilemez");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Lütfen Ücret alanını boş geçilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Görsel alanını boş geçilemez");
            RuleFor(x => x.Img1).NotEmpty().WithMessage("Görsel alanını boş geçilemez");
            RuleFor(x => x.Img2).NotEmpty().WithMessage("Görsel alanını boş geçilemez");
            RuleFor(x => x.Img3).NotEmpty().WithMessage("Görsel alanını boş geçilemez");
            RuleFor(x => x.Img4).NotEmpty().WithMessage("Görsel alanını boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Proje adı en az 5 karakterden oluşmak zorundadır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Proje adı en fazla 50 karakterden oluşmalıdır.");

        }
    }
}
