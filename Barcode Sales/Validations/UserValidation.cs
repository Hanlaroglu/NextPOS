using FluentValidation;
using System;

namespace Barcode_Sales.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public static readonly string StoreNotSelected = "Mağaza seçimi edilmədi";
        public static readonly string RoleNotSelected = "İstifadəçi rolu seçilmədi";
        public static readonly string ExistingUsername = "İstifadəçi adı sistemdə mövcuddur";
        public static readonly string ErrorUsernamePassword = "İstifadəçi adı vəya şifrəsi yanlışdır";
        public static readonly string UserStatusDeactivated = "İstifadəçi deaktiv edilib";
        public UserValidation()
        {
            RuleFor(x => x.StoreId).NotNull().WithMessage(StoreNotSelected);
            RuleFor(x => x.Username).NotEmpty().WithMessage("İstifadəçi adı qeyd edilmədi");
            RuleFor(x => x.Password).NotEmpty().WithMessage("İstifadəçi şifrəsi boş olabilməz");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("İstifadəçi şifrəsi minimum 5 simvol olmalıdır");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad və Soyad daxil edin");
        }

        
        public static bool AuthorizationControl(User user, Func<Role, bool?> permissionSelector)
        {
            return permissionSelector(user.Role) == true;
        }
    }
}
