using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebAPIControllers.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // Log exception to a text file
            string logMessage =
                $"[{DateTime.Now}] {context.Exception.Message}{Environment.NewLine}" +
                $"{context.Exception.StackTrace}{Environment.NewLine}{Environment.NewLine}";

            File.AppendAllText("ErrorLog.txt", logMessage);

            context.Result = new ObjectResult(new
            {
                Message = "An internal server error occurred.",
                Error = context.Exception.Message
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}