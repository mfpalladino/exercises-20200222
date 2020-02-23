namespace CashlessRegistration.TokenService.App.Infrastructure.ErrorHandling
{
    public class ErrorResponse
    {
        public string Message { get; }

        public ErrorResponse(string message)
        {
            Message = message;
        }
    }
}