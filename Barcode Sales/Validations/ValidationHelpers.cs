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
        public static readonly string DatetimeFormatError = "Tarix düzgün daxil edilmədi";


        public static ValidationResult ValidateMessage<T>(T entity, IValidator<T> validator, XtraForm form)
        {
            var validateResult = validator.Validate(entity);
            if (!validateResult.IsValid)
            {
                foreach (var error in validateResult.Errors)
                {
                    NotificationHelpers.Messages.WarningMessage(form, error.ErrorMessage);
                    break;
                }
            }

            return validateResult;
        }

        public static bool IsValidDate(string text)
        {
            return DateTime.TryParse(text, out _);
        }
    }
}