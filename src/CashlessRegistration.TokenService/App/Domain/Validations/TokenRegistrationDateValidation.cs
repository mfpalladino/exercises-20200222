using System;
using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Validations
{
    public static partial class RuleBuilderExceptions
    {
        public static IRuleBuilderOptions<T, DateTime> TokenRegistrationDateValidation<T>(this IRuleBuilder<T, DateTime> rule)
        {
            return rule.NotEmpty().WithMessage("RegistrationDate must be informed");
        }
    }
}
