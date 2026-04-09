using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class StoreValidation : AbstractValidator<Store>
    {
        public StoreValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Flial adı boş ola bilməz");
            RuleFor(x => x.WarehouseId).NotEmpty().NotEqual(0).WithMessage("Anbar seçimi edilmədi");
        }
    }
}
