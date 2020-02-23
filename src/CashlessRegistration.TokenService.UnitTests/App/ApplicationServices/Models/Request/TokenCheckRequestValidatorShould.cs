using System;
using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Request;
using FluentValidation.TestHelper;
using Xunit;

namespace CashlessRegistration.TokenService.UnitTests.App.ApplicationServices.Models.Request
{
    public class TokenCheckRequestValidatorShould
    {
        private readonly TokenCheckRequestValidator _validator;

        public TokenCheckRequestValidatorShould()
        {
            _validator = new TokenCheckRequestValidator();
        }

        [Fact]
        public void HaveErrorWhenTokenIsZero()
        {
            _validator.ShouldHaveValidationErrorFor(request => request.Token, new TokenCheckRequest{Cvv = 100, Token = 0, RegistrationDate = DateTime.Now});
        }

        [Fact]
        public void HaveErrorWhenTokenIsNegative()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.Token, new TokenCheckRequest { Cvv = 100, Token = -1, RegistrationDate = DateTime.Now });
        }

        [Fact]
        public void HaveErrorWhenCvvIsZero()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.Cvv, new TokenCheckRequest { Cvv = 0, Token = 23652356752, RegistrationDate = DateTime.Now });
        }

        [Fact]
        public void HaveErrorWhenCvvIsNegative()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.Cvv, new TokenCheckRequest { Cvv = -1, Token = 23652356752, RegistrationDate = DateTime.Now });
        }

        [Fact]
        public void HaveErrorWhenCvvHasMoreThan3Digits()
        {
            //Assert
            _validator.ShouldHaveValidationErrorFor(request => request.Cvv, new TokenCheckRequest { Cvv = 1000, Token = 23652356752, RegistrationDate = DateTime.Now });
        }
    }
}
