using CashlessRegistration.TokenService.App.Domain.Validations;
using FluentValidation;

namespace CashlessRegistration.TokenService.App.ApplicatonServices.Models.Request
{
    public class TokenCheckRequestValidator : AbstractValidator<TokenCheckRequest>
    {
        public TokenCheckRequestValidator()
        {
            RuleFor(x => x.Token).ValidateToken();
            RuleFor(x => x.Cvv).ValidateCardCvvNumber();
            RuleFor(x => x.RegistrationDate).ValidateTokenRegistrationDate();
        }
    }
}