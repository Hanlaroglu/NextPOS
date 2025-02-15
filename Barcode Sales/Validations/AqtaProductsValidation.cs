using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Validations
{
    public class AqtaProductsValidation:AbstractValidator<AqtaProducts>
    {
        public AqtaProductsValidation()
        {
            RuleFor(x => x.CategoryID).NotEmpty().NotNull().WithMessage(ValidationHelpers.CategoryNotSelected);
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Məhsul adını qeyd edin");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barkod təyin edilmədi");
            RuleFor(x => x.SalePrice).NotEmpty().WithMessage("Satış qiyməti təyin edilmədi");
            RuleFor(x => x.Unit).NotEmpty().WithMessage("Vahid seçimi edilmədi");
            //RuleFor(x => x.Tax).NotEmpty().WithMessage("Vergi dərəcəsi seçilmədi");
        }
    }
}