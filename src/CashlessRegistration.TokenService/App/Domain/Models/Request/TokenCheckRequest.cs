using System;

namespace CashlessRegistration.TokenService.App.Domain.Models.Request
{
    public class TokenCheckRequest
    {
        public DateTime RegistrationDate { get; set; }
        public long Token { get; set; }
        public int Cvv { get; set; }
    }

}