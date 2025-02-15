using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class SupplierPaymentValidation : AbstractValidator<SupplierPayment>
    {
        public SupplierPaymentValidation()
        {
            RuleFor(x=> x.PayDate).NotEmpty().WithMessage("Ödəniş tarixi qeyd edilmədi");
            RuleFor(x => x.PaymentType).NotEmpty().WithMessage("Ödəniş növü seçimi edilmədi");
            RuleFor(x => x.DebtPaid).GreaterThanOrEqualTo(0).WithMessage("Əsas məbləğ mənfi olabilməz");
            RuleFor(x => x.TaxPaid).GreaterThanOrEqualTo(0).WithMessage("ƏDV məbləği mənfi olabilməz");
            RuleFor(x => x).Must(p => p.TaxPaid > 0 || p.DebtPaid > 0).WithMessage("Əsas məbləğ ilə ədv məbləğin ödənişi 0 olabilməz");
        }
    }
}