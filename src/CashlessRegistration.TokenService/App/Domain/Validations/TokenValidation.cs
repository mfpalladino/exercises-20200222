using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Validations
{
    public static partial class RuleBuilderExceptions
    {
        public static IRuleBuilderOptions<T, long> TokenValidation<T>(this IRuleBuilder<T, long> rule)
        {
            return rule.Must(x => x > 0).WithMessage("Token must be greather than zero");
        }
    }
}
