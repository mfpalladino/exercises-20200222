using System;
using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.Domain.Models.Request;
using CashlessRegistration.TokenService.App.Domain.Models.Response;
using CashlessRegistration.TokenService.App.Domain.ValueObjects;
using CashlessRegistration.TokenService.App.Infrastructure.Clock;
using CashlessRegistration.TokenService.App.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CashlessRegistration.TokenService.App.Domain.Services
{

    public class TokenCheckService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly ITokenClock _tokenClock;
        private readonly ITokenGeneratorStrategy _tokenGeneratorStrategy;

        public TokenCheckService(IDatabaseContext databaseContext, ITokenClock tokenClock,  ITokenGeneratorStrategy tokenGeneratorStrategy)
        {
            _databaseContext = databaseContext;
            _tokenClock = tokenClock;
            _tokenGeneratorStrategy = tokenGeneratorStrategy;
        }

        public async Task<TokenCheckResponse> CheckAsync(TokenCheckRequest tokenCheckRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            //TODO has this class many responsabilities? 

            if (tokenCheckRequest == null)
                throw new ArgumentNullException(nameof(tokenCheckRequest));

            const int tokenRegitrationTtlInMinutes = 15;

            if (_tokenClock.Now().Subtract(tokenCheckRequest.RegistrationDate).Minutes > tokenRegitrationTtlInMinutes)
                return TokenCheckResponse.Invalid;

            var savedTokenRegistration = await _databaseContext.TokenRegistrations.FirstOrDefaultAsync(x => 
                x.Id == tokenCheckRequest.Token &&
                x.GeneratedAt == tokenCheckRequest.RegistrationDate, cancellationToken: cancellationToken);

            if (savedTokenRegistration == null)
                return TokenCheckResponse.Invalid;

            var generatedToken = _tokenGeneratorStrategy.Generate(new Card(savedTokenRegistration.CardNumber, tokenCheckRequest.Cvv));
            if (!generatedToken.Value.Equals(savedTokenRegistration.Id))
                return TokenCheckResponse.Invalid;

            return TokenCheckResponse.Valid;
        }
    }
}