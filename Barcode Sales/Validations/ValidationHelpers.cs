using DevExpress.XtraEditors;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Barcode_Sales.Validations
{
    public class ValidationHelpers
    {
        public static readonly string CategoryNotSelected = "Kateqoriya seçimi edilmədi";
        public static readonly string DatetimeFormatError = "Yanlış tarix formatı";


        public static ValidationResult ValidateMessage<T>(T entity, IValidator<T> validator, XtraForm form)
        {
            var validateResult = validator.Validate(entity);
            if (!validateResult.IsValid)
            {
                foreach (var error in validateResult.Errors)
                {
                    NoticationHelpers.Messages.WarningMessage(form, error.ErrorMessage);
                    //OperationsControl.Message(error.ErrorMessage, fMessage.enmType.Warning);
                    break;
                }
            }

            return validateResult;
        }

        public static bool Any<T>(Expression<Func<T, bool>> expression) where T : class
        {
            using (var db = new NextposDBEntities())
            {
                var dbSet = db.Set<T>();

                // "IsDeleted" sütununun olub olmadığını kontrol et
                var isDeletedProperty = typeof(T).GetProperty("IsDeleted");

                if (isDeletedProperty != null)
                {
                    // "IsDeleted" sütunu varsa ona uyğun bir filter əlavə et
                    var filteredQuery = dbSet.Where(BuildIsDeletedFilter<T>());
                    return filteredQuery.Any(expression);
                }

                // "IsDeleted" sütunu yoxdursa birbaşa işlət
                return dbSet.Any(expression);
            }
        }

        private static Expression<Func<T, bool>> BuildIsDeletedFilter<T>() where T : class
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, "IsDeleted");
            var constant = Expression.Constant(0, typeof(int));

            // Əgər nullable'dirsə, öncə HasValue kontrolunu et
            if (property.Type == typeof(int?))
            {
                var hasValue = Expression.Property(property, "HasValue");
                var value = Expression.Property(property, "Value");
                var equality = Expression.Equal(value, constant);

                // HasValue == true və Value == 0
                var combined = Expression.AndAlso(hasValue, equality);
                return Expression.Lambda<Func<T, bool>>(combined, parameter);
            }

            // Nullable deyilsə birbaşa qarşılaştır
            var equalityDirect = Expression.Equal(property, constant);
            return Expression.Lambda<Func<T, bool>>(equalityDirect, parameter);
        }
    }
}