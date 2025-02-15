using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class ProductValidation : AbstractValidator<Products>
    {
        public ProductValidation()
        {
            //RuleFor(x => x.WarehousesID).NotEmpty().WithMessage("Anbar seçimi edilmədi");
            RuleFor(x => x.CategoryID).NotNull().WithMessage(ValidationHelpers.CategoryNotSelected);
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Məhsul adını qeyd edin");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barkod təyin edilmədi");
            RuleFor(x => x.SalePrice).NotEmpty().WithMessage("Satış qiyməti təyin edilmədi");
            RuleFor(x => x.Unit).NotEmpty().WithMessage("Vahid seçimi edilmədi");
            RuleFor(x => x.Tax).NotEmpty().WithMessage("Vergi dərəcəsi seçilmədi");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Məhsul adını qeyd edin");
        }
    }
}