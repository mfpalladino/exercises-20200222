using System;
using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Validations
{
    public static partial class TokenRegistrationDateValidation
    {
        public static IRuleBuilderOptions<T, DateTime> ValidateTokenRegistrationDate<T>(this IRuleBuilder<T, DateTime> rule)
        {
            return rule.NotEmpty().WithMessage("RegistrationDate must be informed");
        }
    }
}
