using System;

namespace CashlessRegistration.TokenService.App.Domain.Entities
{
    public class TokenRegistration
    {
        public long Id { get; }
        public long CardNumber { get; }

        public DateTime GeneratedAt { get; }

        public TokenRegistration(long id, long cardNumber, DateTime generatedAt)
        {
            Id = id;
            CardNumber = cardNumber;
            GeneratedAt = generatedAt;
        }
    }
}
