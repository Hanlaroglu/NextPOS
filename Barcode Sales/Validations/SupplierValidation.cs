using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class SupplierValidation : AbstractValidator<Suppliers>
    {
        public SupplierValidation()
        {
            RuleFor(x => x.SupplierName).NotEmpty().WithMessage("Təchizatçı adı boş olabilməz");
        }
    }
}