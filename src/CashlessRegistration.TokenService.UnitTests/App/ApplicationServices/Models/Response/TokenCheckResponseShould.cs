using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Response;
using FluentAssertions;
using Xunit;

namespace CashlessRegistration.TokenService.UnitTests.App.ApplicationServices.Models.Response
{
    public class TokenCheckResponseShould
    {
        [Fact]
        public void RetunValidWhenUsingValidPublicStaticMember()
        {
            TokenCheckResponse.Valid.Validated.Should().BeTrue();
        }

        [Fact]
        public void RetunInvalidWhenUsingInvalidPublicStaticMember()
        {
            TokenCheckResponse.Invalid.Validated.Should().BeFalse();
        }
    }
}
