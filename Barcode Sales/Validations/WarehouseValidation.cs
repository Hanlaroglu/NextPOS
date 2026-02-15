using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class WarehouseValidation:AbstractValidator<Warehouse>
    {
        public WarehouseValidation()
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Anbar adı boş ola bilməz");
        }
    }
}