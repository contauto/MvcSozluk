using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş bırakılamaz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter girilmeli.");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("30 karakterden fazla girilemez.");
        }
    }
}
