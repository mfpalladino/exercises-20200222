using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.ApplicatonServices;
using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Request;
using CashlessRegistration.TokenService.App.ApplicatonServices.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace CashlessRegistration.TokenService.Controllers
{
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly TokenCreateService _tokenCreateService;
        private readonly TokenCheckService _tokenCheckService;

        public TokensController(TokenCreateService tokenCreateService, TokenCheckService tokenCheckService)
        {
            _tokenCreateService = tokenCreateService;
            _tokenCheckService = tokenCheckService;
        }

        [HttpPost]
        [Route("1.0/api/[controller]/create")]
        public async Task<TokenCreateResponse> Post([FromBody] TokenCreateRequest tokenCreateRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _tokenCreateService.CreateAsync(tokenCreateRequest, cancellationToken);
        }

        [HttpPost]
        [Route("1.0/api/[controller]/check")]
        [HttpPost]
        public async Task<TokenCheckResponse> Post([FromBody] TokenCheckRequest tokenCheckRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _tokenCheckService.CheckAsync(tokenCheckRequest, cancellationToken);
        }
    }
}
