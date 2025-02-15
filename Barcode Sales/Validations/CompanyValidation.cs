using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Validations
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Vergi Ödəyicisinin adı boş olabilməz");
            RuleFor(x => x.Voen).NotEmpty().WithMessage("VÖEN boş olabilməz");
            RuleFor(x => x.CompanyCode).NotEmpty().WithMessage("Obyekt kodu boş olabilməz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Obyektin ünvanı boş olabilməz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon nömrəsi boş olabilməz");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Elektron poçt ünvanı boş olabilməz");
            RuleFor(x => x.RegistrationDate).NotEmpty().WithMessage("Qeydiyyat tarixi seçimi edilmədi");
        }
    }
}
