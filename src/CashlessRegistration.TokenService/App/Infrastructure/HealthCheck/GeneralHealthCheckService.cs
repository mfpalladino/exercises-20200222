using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.Infrastructure.EF;

namespace CashlessRegistration.TokenService.App.Infrastructure.HealthCheck
{
    public class GeneralHealthCheckService
    {
        private readonly IDatabaseContext _databaseContext;

        public GeneralHealthCheckService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CheckAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _databaseContext.CheckConnectionAsync(cancellationToken);
        }
    }
}