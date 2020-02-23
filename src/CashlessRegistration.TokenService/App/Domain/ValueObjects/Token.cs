using System;

namespace CashlessRegistration.TokenService.App.Domain.ValueObjects
{
    public struct Token
    {
        public long Value { get; }
        public DateTime GeneratedAt { get; }

        public Token(long token, DateTime generatedAt)
        {
            Value = token;
            GeneratedAt = generatedAt;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Token))
                return false;

            var token = (Token)obj;
            return Value == token.Value &&
                   GeneratedAt == token.GeneratedAt;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, GeneratedAt);
        }
    }
}
