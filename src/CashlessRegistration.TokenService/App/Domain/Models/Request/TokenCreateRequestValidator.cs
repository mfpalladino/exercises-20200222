using CashlessRegistration.TokenService.App.Domain.Validations;
using FluentValidation;

namespace CashlessRegistration.TokenService.App.Domain.Models.Request
{
    public class TokenCreateRequestValidator : AbstractValidator<TokenCreateRequest>
    {

        public TokenCreateRequestValidator()
        {
            RuleFor(x => x.CardNumber).CardNumberValidation();
            RuleFor(x => x.Cvv).CardCvvNumberValidation();
        }
    }
}