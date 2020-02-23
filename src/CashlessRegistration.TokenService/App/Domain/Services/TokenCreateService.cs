using System;
using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.Domain.Entities;
using CashlessRegistration.TokenService.App.Domain.Models.Request;
using CashlessRegistration.TokenService.App.Domain.Models.Response;
using CashlessRegistration.TokenService.App.Domain.ValueObjects;
using CashlessRegistration.TokenService.App.Infrastructure.EF;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public class TokenCreateService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly ITokenGeneratorStrategy _tokenGeneratorStrategy;

        public TokenCreateService(IDatabaseContext databaseContext,  ITokenGeneratorStrategy tokenGeneratorStrategy)
        {
            _databaseContext = databaseContext;
            _tokenGeneratorStrategy = tokenGeneratorStrategy;
        }

        public async Task<TokenCreateResponse> CreateAsync(TokenCreateRequest tokenCreateRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            //TODO handle concurrency
            //TODO business rule: should we receive a deviceId to "connect" the token with that device? 
            if (tokenCreateRequest == null)
                throw new ArgumentNullException(nameof(tokenCreateRequest));

            var generatedToken = _tokenGeneratorStrategy.Generate(new Card(tokenCreateRequest.CardNumber, tokenCreateRequest.Cvv));

            var tokenRegistration = new TokenRegistration(generatedToken.Value, tokenCreateRequest.CardNumber, generatedToken.From);
            _databaseContext.TokenRegistrations.Add(tokenRegistration);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            return new TokenCreateResponse(generatedToken.From, generatedToken.Value);
        }
    }
}