using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı kısmı boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmı boş olamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş olamaz");
        }
    }
}
