using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class ProductValidation : AbstractValidator<Products>
    {
        public ProductValidation()
        {
            RuleFor(x => x.SupplierId).NotEqual(0).WithMessage("Təchizatçı seçimi edilmədi");
            RuleFor(x => x.CategoryId).NotEqual(0).WithMessage(ValidationHelpers.CategoryNotSelected);
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Məhsul adını qeyd edin");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barkod təyin edilmədi");
            RuleFor(x => x.TaxId).NotEqual(0).WithMessage("Vergi dərəcəsi seçilmədi");
        }
    }
}