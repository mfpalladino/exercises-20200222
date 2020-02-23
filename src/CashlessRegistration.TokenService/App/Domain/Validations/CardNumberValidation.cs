using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Validations
{
    public static partial class RuleBuilderExceptions
    {
        public static IRuleBuilderOptions<T, long> CardNumberValidation<T>(this IRuleBuilder<T, long> rule)
        {
            const int maximumCardNumberChars = 16;

            return rule
                .Must(x => x > 0).WithMessage("Card number must be greather than zero")
                .Must(x => x.ToString().Length <= maximumCardNumberChars).WithMessage($"Card number can't contains more than {maximumCardNumberChars} chars");
        }
    }
}
