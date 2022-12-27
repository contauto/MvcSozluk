using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail kısmı boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmı boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı kısmı boş olamaz");
        }
    }
}
