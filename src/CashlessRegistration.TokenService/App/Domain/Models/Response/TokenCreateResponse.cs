using System;

namespace CashlessRegistration.TokenService.App.Domain.Models.Response
{
    public class TokenCreateResponse
    {
        public DateTime RegistrationDate { get; }
        public long Token { get; }

        public TokenCreateResponse(DateTime registrationDate, long token)
        {
            RegistrationDate = registrationDate;
            Token = token;
        }
    }
}