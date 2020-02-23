namespace CashlessRegistration.TokenService.App.ApplicatonServices.Models.Request
{
    public class TokenCreateRequest
    {
        public long CardNumber { get; set; }
        public int Cvv { get; set; }
    }
}