using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class CustomerValidation:AbstractValidator<Customers>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad və soyad boş buraxılabilməz");
        }
    }
}
