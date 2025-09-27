using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class CustomerGroupValidation : AbstractValidator<CustomerGroup>
    {
        public CustomerGroupValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Qrup adı boş ola bilməz");

            RuleFor(x=> x.Discount).GreaterThanOrEqualTo(0)
                .WithMessage("Endirim mənfi ola bilməz");
            
            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100)
                .WithMessage("Endirim 0 ilə 100 arasında olmalıdır");
        }
    }
}
