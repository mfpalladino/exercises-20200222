using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CashlessRegistration.TokenService.App.Infrastructure.ErrorHandling
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            //TODO search a better way to inject this dependency
            var logger = (ILogger<ExceptionHandlingAttribute>)context.HttpContext.RequestServices.GetService(typeof(ILogger<ExceptionHandlingAttribute>));

            var exception = context.Exception;

            logger.LogError(exception, exception.Message);
            const int code = (int)HttpStatusCode.InternalServerError;
            context.Result = new StatusCodeResult(code);

            context.HttpContext.Response.StatusCode = code;
            await base.OnExceptionAsync(context);
        }
    }
}