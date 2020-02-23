using System;
using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Request;
using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Response;
using CashlessRegistration.TokenService.App.Domain.Repositories;
using CashlessRegistration.TokenService.App.Domain.Services;
using CashlessRegistration.TokenService.App.Domain.ValueObjects;
using CashlessRegistration.TokenService.App.Infrastructure.EF;

namespace CashlessRegistration.TokenService.App.ApplicatonServices
{

    public class TokenCheckService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly ITokenTtlChecker _tokenTtlChecker;
        private readonly ITokenGenerator _tokenGenerator;

        public TokenCheckService(IDatabaseContext databaseContext, ITokenTtlChecker tokenTtlChecker,  ITokenGenerator tokenGenerator)
        {
            _databaseContext = databaseContext;
            _tokenTtlChecker = tokenTtlChecker;
            _tokenGenerator = tokenGenerator;
        }

        public Task<TokenCheckResponse> CheckAsync(TokenCheckRequest tokenCheckRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (tokenCheckRequest == null)
                throw new ArgumentNullException(nameof(tokenCheckRequest));

            return InternalCheckAsync(tokenCheckRequest, cancellationToken);
        }

        private async Task<TokenCheckResponse> InternalCheckAsync(TokenCheckRequest tokenCheckRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!_tokenTtlChecker.IsValid(tokenCheckRequest.RegistrationDate))
                return TokenCheckResponse.Invalid;

            var tokenRegistration = await _databaseContext.TokenRegistrations.GetAsync(tokenCheckRequest.Token,
                tokenCheckRequest.RegistrationDate, cancellationToken);

            if (tokenRegistration == null)
                return TokenCheckResponse.Invalid;

            if (!_tokenGenerator.IsValid(new Card(tokenRegistration.CardNumber, tokenCheckRequest.Cvv), tokenCheckRequest.RegistrationDate, tokenRegistration.Id))
                return TokenCheckResponse.Invalid;

            return TokenCheckResponse.Valid;
        }
    }
}