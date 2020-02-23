using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Request;
using FluentValidation.TestHelper;
using Xunit;

namespace CashlessRegistration.TokenService.UnitTests.App.ApplicationServices.Models.Request
{
    public class TokenCreateRequestValidatorShould
    {
        private readonly TokenCreateRequestValidator _validator;

        public TokenCreateRequestValidatorShould()
        {
            _validator = new TokenCreateRequestValidator();
        }

        [Fact]
        public void HaveErrorWhenCardNumberIsZero()
        {
            _validator.ShouldHaveValidationErrorFor(request => request.CardNumber, new TokenCreateRequest { CardNumber = 0, Cvv = 100});
        }

        [Fact]
        public void HaveErrorWhenCardNumberIsNegative()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.CardNumber, new TokenCreateRequest { CardNumber = -1, Cvv = 100 });
        }

        [Fact]
        public void HaveErrorWhenCardNumberHasMoreThan16Digits()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.CardNumber, new TokenCreateRequest { CardNumber = 100000000000000000, Cvv = 100 });
        }

        [Fact]
        public void HaveErrorWhenCvvIsZero()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.Cvv, new TokenCreateRequest { CardNumber = 12122, Cvv = 0 });
        }

        [Fact]
        public void HaveErrorWhenCvvIsNegative()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.Cvv, new TokenCreateRequest { CardNumber = 12122, Cvv = -1 });
        }

        [Fact]
        public void HaveErrorWhenCvvHasMoreThan3Digits()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.Cvv, new TokenCreateRequest { CardNumber = 12122, Cvv = 1000 });
        }
    }
}
