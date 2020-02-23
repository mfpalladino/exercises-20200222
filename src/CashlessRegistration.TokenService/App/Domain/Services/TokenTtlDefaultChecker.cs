using System;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public class TokenTtlDefaultChecker : ITokenTtlChecker
    {
        private readonly ITokenGeneratorClock _tokenGeneratorClock;

        public TokenTtlDefaultChecker(ITokenGeneratorClock tokenGeneratorClock)
        {
            _tokenGeneratorClock = tokenGeneratorClock ?? throw new ArgumentNullException(nameof(tokenGeneratorClock));
        }

        public bool IsValid(DateTime datetime)
        {
            const int tokenRegitrationTtlInMinutes = 15;
            return _tokenGeneratorClock.Now().Subtract(datetime).Minutes <= tokenRegitrationTtlInMinutes;
        }
    }

}