using System;
using CashlessRegistration.Shared;
using CashlessRegistration.TokenService.App.Domain.ValueObjects;
using CashlessRegistration.TokenService.App.Infrastructure.Clock;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public class TokenGeneratorDefaultStrategy : ITokenGeneratorStrategy
    {
        private const int AbsoluteDifferenceToFilterBaseToken = 5;
        private readonly ITokenClock _tokenClock;

        public TokenGeneratorDefaultStrategy(ITokenClock tokenClock)
        {
            _tokenClock = tokenClock ?? throw new ArgumentNullException(nameof(tokenClock));
        }

        public Token Generate(Card card)
        {
            var baseDateTime = _tokenClock.Now();
            var baseToken = card.Number.ToString() +
                            baseDateTime.Year +
                            baseDateTime.Month.ToString().PadLeft(2, '0') +
                            baseDateTime.Day.ToString().PadLeft(2, '0') +
                            baseDateTime.Hour.ToString().PadLeft(2, '0') +
                            baseDateTime.Minute.ToString().PadLeft(2, '0');

            var baseTokenAsIntArray = baseToken.ToIntArray();
            var filteredByAbsoluteDiffrenceBaseToken = baseTokenAsIntArray.FindByAbsoluteDifference(AbsoluteDifferenceToFilterBaseToken);
            var rotatedToRightBaseToken = filteredByAbsoluteDiffrenceBaseToken.RotateToRight(card.Cvv);

            return new Token(rotatedToRightBaseToken.ToLong(), baseDateTime);
        }
    }
}
