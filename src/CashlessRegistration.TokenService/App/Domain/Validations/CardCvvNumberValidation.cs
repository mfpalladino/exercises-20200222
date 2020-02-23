using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Validations
{
    public static class CardCvvNumberValidation
    {
        public static IRuleBuilderOptions<T, int> ValidateCardCvvNumber<T>(this IRuleBuilder<T, int> rule)
        {
            return rule
                .Must(x => x > 0).WithMessage("Card cvv number must be greather than zero")
                .LessThanOrEqualTo(999).WithMessage("Card CVV number must be less than or equal 999");
        }
    }
}