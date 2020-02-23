using System;

namespace CashlessRegistration.TokenService.App.Domain.ValueObjects
{
    public struct Token
    {
        public long Value { get; }
        public DateTime From { get; }

        public Token(long token, DateTime from)
        {
            if (token <= 0)
                throw new ArgumentOutOfRangeException(nameof(token), "token must be greather than zero");

            Value = token;
            From = @from;
        }
    }
}
