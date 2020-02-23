using System;
using CashlessRegistration.Shared;
using CashlessRegistration.TokenService.App.Domain.ValueObjects;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public class TokenDefaultGenerator : ITokenGenerator
    {
        private const int AbsoluteDifferenceToFilterBaseToken = 5;


        public Token Generate(Card card, DateTime baseDateTime)
        {
            var baseToken = card.Number.ToString() +
                            baseDateTime.Year +
                            baseDateTime.Month.ToString().PadLeft(2, '0') +
                            baseDateTime.Day.ToString().PadLeft(2, '0') +
                            baseDateTime.Hour.ToString().PadLeft(2, '0') +
                            baseDateTime.Minute.ToString().PadLeft(2, '0');

            var baseTokenAsIntArray = baseToken.ToIntArray();
            var filteredByAbsoluteDiffrenceBaseToken = baseTokenAsIntArray.FindByAbsoluteDifference(AbsoluteDifferenceToFilterBaseToken);
            var rotatedToRightBaseToken = filteredByAbsoluteDiffrenceBaseToken.RotateToRight(card.Cvv);

            return new Token(rotatedToRightBaseToken.ToLong(), baseDateTime);
        }

        public bool IsValid(Card card, DateTime baseDateTime, long token)
        {
            var generatedToken = Generate(card, baseDateTime);
            return generatedToken.Value.Equals(token);
        }
    }
}
