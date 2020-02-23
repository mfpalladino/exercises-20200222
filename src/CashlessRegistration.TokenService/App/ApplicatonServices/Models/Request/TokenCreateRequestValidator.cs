using CashlessRegistration.TokenService.App.Domain.Validations;
using FluentValidation;

namespace CashlessRegistration.TokenService.App.ApplicatonServices.Models.Request
{
    public class TokenCreateRequestValidator : AbstractValidator<TokenCreateRequest>
    {

        public TokenCreateRequestValidator()
        {
            RuleFor(x => x.CardNumber).ValidateCardNumber();
            RuleFor(x => x.Cvv).ValidateCardCvvNumber();
        }
    }
}