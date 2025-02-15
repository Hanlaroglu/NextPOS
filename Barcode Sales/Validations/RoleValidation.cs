using FluentValidation;

namespace Barcode_Sales.Validations
{
    public class RoleValidation : AbstractValidator<Roles>
    {
        public static readonly string ExistingRole = "Rol adı sistemdə mövcuddur";

        public RoleValidation()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol adı qeyd edilmədi");
        }
    }
}