using System;

namespace CashlessRegistration.TokenService.App.Domain.ValueObjects
{
    public struct Card
    {
        public long Number { get; }
        public int Cvv { get; }

        public Card(long number, int cvv)
        {
            Number = number;
            Cvv = cvv;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Card))
                return false;

            var card = (Card)obj;
            return Number == card.Number && Cvv == card.Cvv;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number, Cvv);
        }
    }
}
