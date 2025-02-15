using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class SupplierDebtValidation : AbstractValidator<SuppliersDebt>
    {
        public SupplierDebtValidation()
        {
            RuleFor(x=> x).Must(p=> p.SupplierId != 0).WithMessage("Təchizatçı seçimi edilmədi");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Borc adını daxil edin");
            RuleFor(x => x.Debt).GreaterThanOrEqualTo(0).WithMessage("Əsas məbləğ mənfi olabilməz");
            RuleFor(x => x.TaxDebt).GreaterThanOrEqualTo(0).WithMessage("ƏDV məbləği mənfi olabilməz");
            RuleFor(x => x).Must(p => p.Debt > 0 || p.TaxDebt > 0).WithMessage("Əsas məbləğ vəya ədv məbləğin ödənişi 0 olabilməz");
        }
    }
}