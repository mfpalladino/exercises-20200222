using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Validations
{
    public static class CardNumberValidation
    {
        public static IRuleBuilderOptions<T, long> ValidateCardNumber<T>(this IRuleBuilder<T, long> rule)
        {
            return rule
                .Must(x => x > 0).WithMessage("Card number must be greather than zero")
                .LessThanOrEqualTo(9999999999999999).WithMessage($"Card number must be less than or equal 9999999999999999");
        }
    }
}
