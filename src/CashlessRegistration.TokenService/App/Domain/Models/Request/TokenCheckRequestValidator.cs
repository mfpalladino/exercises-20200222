using CashlessRegistration.TokenService.App.Domain.Validations;
using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Models.Request
{
    public class TokenCheckRequestValidator : AbstractValidator<TokenCheckRequest>
    {
        public TokenCheckRequestValidator()
        {
            RuleFor(x => x.Token).TokenValidation();
            RuleFor(x => x.Cvv).CardCvvNumberValidation();
            RuleFor(x => x.RegistrationDate).TokenRegistrationDateValidation();
        }
    }
}