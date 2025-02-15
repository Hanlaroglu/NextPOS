using Barcode_Sales.Helpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Validations
{
    public class TerminalValidation : AbstractValidator<Terminals>
    {
        public TerminalValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Operator seçimi edilmədi");
            RuleFor(x => x.IpAddress).NotEmpty()
                                     .WithMessage("İp adresi boş buraxılabilməz")
                                     .Must(BeValidIpAddressAndPort)
                                     .WithMessage("Etibarlı IP ünvanı və port daxil edin. Misal: 192.168.1.1:8080")
                                     .When(x=> x.Name != nameof(Enums.KassaOperator.XPRINTER));

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
