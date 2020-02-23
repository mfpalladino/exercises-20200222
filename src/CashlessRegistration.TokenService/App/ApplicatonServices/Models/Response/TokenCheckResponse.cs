namespace CashlessRegistration.TokenService.App.ApplicatonServices.Models.Response
{
    public class TokenCheckResponse
    {
        public static readonly TokenCheckResponse Invalid = new TokenCheckResponse(false);
        public static readonly TokenCheckResponse Valid = new TokenCheckResponse(true);

        public bool Validated { get; }

        public TokenCheckResponse(bool validated)
        {
            Validated = validated;
        }
    }

}