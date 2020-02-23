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
    }
}
