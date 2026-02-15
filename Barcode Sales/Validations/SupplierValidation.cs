using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(x => x.SupplierName).NotEmpty().WithMessage("Təchizatçı adı boş olabilməz");
        }
    }
}