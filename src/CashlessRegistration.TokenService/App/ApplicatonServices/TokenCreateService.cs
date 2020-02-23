using System;
using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Request;
using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Response;
using CashlessRegistration.TokenService.App.Domain.Entities;
using CashlessRegistration.TokenService.App.Domain.Services;
using CashlessRegistration.TokenService.App.Domain.ValueObjects;
using CashlessRegistration.TokenService.App.Infrastructure.EF;

namespace CashlessRegistration.TokenService.App.ApplicatonServices
{
    public class TokenCreateService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly ITokenGeneratorClock _tokenGeneratorClock;
        private readonly ITokenGenerator _tokenGenerator;

        public TokenCreateService(IDatabaseContext databaseContext, ITokenGeneratorClock tokenGeneratorClock, ITokenGenerator tokenGenerator)
        {
            _databaseContext = databaseContext;
            _tokenGeneratorClock = tokenGeneratorClock;
            _tokenGenerator = tokenGenerator;
        }

        public Task<TokenCreateResponse> CreateAsync(TokenCreateRequest tokenCreateRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (tokenCreateRequest == null)
                throw new ArgumentNullException(nameof(tokenCreateRequest));

            return InternalCreateAsync(tokenCreateRequest, cancellationToken);
        }

        private async Task<TokenCreateResponse> InternalCreateAsync(TokenCreateRequest tokenCreateRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            //TODO business rule: should we receive a deviceId to "connect" the token with that device? 
            var generatedToken = _tokenGenerator.Generate(new Card(tokenCreateRequest.CardNumber, tokenCreateRequest.Cvv), _tokenGeneratorClock.Now());

            var tokenRegistration = new TokenRegistration(generatedToken.Value, tokenCreateRequest.CardNumber, generatedToken.GeneratedAt);
            _databaseContext.TokenRegistrations.Add(tokenRegistration);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            return new TokenCreateResponse(generatedToken.GeneratedAt, generatedToken.Value);
        }
    }
}