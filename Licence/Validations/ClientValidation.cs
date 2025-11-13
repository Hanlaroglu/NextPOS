using FluentValidation;
using Licence.Models;

namespace Licence.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Vergi ödəyicisinin adı daxil edilmədi");

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("Obyektin adı daxil edilmədi");

            RuleFor(x => x.Voen)
                .MinimumLength(10)
                .WithMessage("VÖEN nömrəsi 10 simvoldan ibarət olmalıdır");

            RuleFor(x => x.CompanyCode)
                .NotEmpty()
                .WithMessage("Obyekt kodu daxil edilmədi");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Ünvan daxil edilmədi");

            RuleFor(x => x.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Əlaqə nömrəsi daxil edilmədi")
                .Must(x => x != "(___)___-__-__")
                .WithMessage("Əlaqə nömrəsi düzgün daxil edilmədi");

            RuleFor(x => x.TerminalModel)
                .NotEmpty()
                .WithMessage("Kassa seçimi edilmədi");

            RuleFor(x => x.TerminalSerialNumber)
                .NotEmpty()
                .When(x => x.TerminalModel != "YOXDUR ")
                .WithMessage("Kassa seriya nömrəsi daxil edilmədi");
        }
    }
}