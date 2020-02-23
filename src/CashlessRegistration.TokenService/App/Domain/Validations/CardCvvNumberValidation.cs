using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Validations
{
    public static partial class RuleBuilderExceptions
    {
        public static IRuleBuilderOptions<T, int> CardCvvNumberValidation<T>(this IRuleBuilder<T, int> rule)
        {
            const int maximumCardCvvChars = 3;

            return rule
                .Must(x => x > 0).WithMessage("Card cvv number must be greather than zero")
                .Must(x => x.ToString().Length <= maximumCardCvvChars).WithMessage($"Card CVV number can't contains more than {maximumCardCvvChars} chars");
        }
    }
}