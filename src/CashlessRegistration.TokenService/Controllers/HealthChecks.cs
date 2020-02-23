using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.ApplicatonServices;
using Microsoft.AspNetCore.Mvc;

namespace CashlessRegistration.TokenService.Controllers
{
    [ApiController]
    public class HealthChecksController : ControllerBase
    {
        private readonly GeneralHealthCheckService _generalHealthCheckService;

        public HealthChecksController(GeneralHealthCheckService generalHealthCheckService)
        {
            _generalHealthCheckService = generalHealthCheckService;
        }

        [HttpGet]
        [Route("1.0/api/[controller]/general/check")]
        public async Task Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _generalHealthCheckService.CheckAsync(cancellationToken);
        }
    }
}
