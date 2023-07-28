using AspCore_0307.Areas.Writer.Models;
using FluentValidation;

namespace AspCore_0307.Areas.Writer.WriterValidationRules
{
    public class UserEditViewModelValidator:AbstractValidator<UserEditViewModel>
    {
       public UserEditViewModelValidator() {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanını doldurunuz.");
            RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("Eşleşecek parola boş geçilemez.");
        }
    }
}
