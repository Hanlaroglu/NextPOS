using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class ScaleValidation : AbstractValidator<Scale>
    {
        public ScaleValidation()
        {
            RuleFor(x => x.ModelName).NotEmpty().WithMessage("Model seçimi edilmədi");
            RuleFor(x => x.IpAddress).NotEmpty().WithMessage("İp adresi daxil edilmədi");
            RuleFor(x => x.FilePath).NotEmpty().WithMessage("Fayl yolu əlavə edilmədi");
        }
    }
}
