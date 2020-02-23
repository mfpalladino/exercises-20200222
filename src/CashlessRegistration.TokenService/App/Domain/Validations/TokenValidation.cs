using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Validations
{
    public static class TokenValidation
    {
        public static IRuleBuilderOptions<T, long> ValidateToken<T>(this IRuleBuilder<T, long> rule)
        {
            return rule.Must(x => x > 0).WithMessage("Token must be greather than zero");
        }
    }
}
