using Barcode_Sales.Helpers;
using FluentValidation;
using System.Net;

namespace Barcode_Sales.Validations
{
    public class TerminalValidation : AbstractValidator<Terminals>
    {
        public TerminalValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Operator seçimi edilmədi");
            RuleFor(x => x.IpAddress).NotEmpty()
                .WithMessage("İp adresi boş buraxılabilməz")
                .WithMessage("Etibarlı IP ünvanı  daxil edin. Misal: 192.168.1.26");

            RuleFor(x => x.MerchantId).NotEmpty()
                                     .WithMessage("MerchantID boş buraxılabilməz")
                                     .When(x => x.Name == nameof(Enums.KassaOperator.AZSMART));

            RuleFor(x => x.UserId).NotEmpty().WithMessage("İstifadəçi seçimi edilmədi");
        }

        private bool BeValidIpAddressAndPort(string ipAddressAndPort)
        {
            if (string.IsNullOrWhiteSpace(ipAddressAndPort))
                return false;

            var parts = ipAddressAndPort.Split(':');
            if (parts.Length != 2)
                return false;

            if (!IPAddress.TryParse(parts[0], out _))
                return false;

            if (int.TryParse(parts[1], out int port))
            {
                return port >= 0 && port <= 65535;
            }

            return false;
        }
    }
}
