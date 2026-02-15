using FluentValidation;
using System;
using System.Data.Entity;
using System.Linq;

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
            RuleFor(x => x.StoreID).NotNull().WithMessage(StoreNotSelected);
            RuleFor(x => x.Username).NotEmpty().WithMessage("İstifadəçi adı qeyd edilmədi");
            RuleFor(x => x.Password).NotEmpty().WithMessage("İstifadəçi şifrəsi boş olabilməz");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("İstifadəçi şifrəsi minimum 5 simvol olmalıdır");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad və Soyad daxil edin");
        }

        public static Tuple<bool, User, string> AuthenticationControl(string username, string password, bool SaveMe = false)
        {
            using (var db = new KhanposDbEntities())
            {
                var control = db.Users.AsNoTracking()
                                .Include(u => u.Role)
                                .FirstOrDefault(x => x.Password == password && x.Username == username);

                if (control is null)
                {
                    return new Tuple<bool, User, string>(false, null, ErrorUsernamePassword);
                }

                if (control.Status is false)
                {
                    return new Tuple<bool, User, string>(false, control, UserStatusDeactivated);
                }

                if (SaveMe is true)
                {
                    Properties.Settings.Default.Username = username;
                    Properties.Settings.Default.Password = password;
                    Properties.Settings.Default.SaveMe = true;
                }
                else
                {
                    Properties.Settings.Default.Username = null;
                    Properties.Settings.Default.Password = null;
                    Properties.Settings.Default.SaveMe = false;
                }

                Properties.Settings.Default.UserID = control.Id;
                Properties.Settings.Default.Save();
                return new Tuple<bool, User, string>(true, control, null);
            }
        }

        public static bool AuthorizationControl(User user, Func<Role, bool?> permissionSelector)
        {
            return permissionSelector(user.Role) == true;
        }
    }
}
