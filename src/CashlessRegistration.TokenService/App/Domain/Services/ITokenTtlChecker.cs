using System;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public interface ITokenTtlChecker
    {
        bool IsValid(DateTime datetime);
    }
}