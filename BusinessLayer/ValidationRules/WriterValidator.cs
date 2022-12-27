using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş bırakılamaz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("En az 2 karakter girilmeli.");
            RuleFor(x => x.WriterSurname).MaximumLength(30).WithMessage("30 karakterden fazla girilemez.");
        }
    }
}
