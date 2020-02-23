using System;
using System.ComponentModel.DataAnnotations;

namespace CashlessRegistration.TokenService.App.Domain.Entities
{
    public class TokenRegistration
    {
        public long Id { get; }
        [Encrypted]
        public long CardNumber { get; }
        public DateTime GeneratedAt { get; }

        public TokenRegistration(long id, long cardNumber, DateTime generatedAt)
        {
            Id = id;
            CardNumber = cardNumber;
            GeneratedAt = generatedAt;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TokenRegistration tokenRegistration))
                return false;

            return tokenRegistration.Id == Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ CardNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ GeneratedAt.GetHashCode();
                return hashCode;
            }
        }
    }
}
