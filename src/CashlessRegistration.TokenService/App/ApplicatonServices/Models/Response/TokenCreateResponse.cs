using System;

namespace CashlessRegistration.TokenService.App.ApplicatonServices.Models.Response
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