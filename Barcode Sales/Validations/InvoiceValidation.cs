using System;
using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class InvoiceValidation:AbstractValidator<Invoice>
    {
        public InvoiceValidation()
        {
            RuleFor(x => x.InvoiceDate).LessThanOrEqualTo(DateTime.Today).WithMessage("Tarix bugündən böyük ola bilməz");
            RuleFor(x => x.WarehouseId).NotEqual(0).WithMessage("Anbar seçimi edilmədi");
            RuleFor(x => x.PaymentTypeId).NotEqual(0).WithMessage("Ödəniş növü seçimi edilmədi");
        }
    }
}
