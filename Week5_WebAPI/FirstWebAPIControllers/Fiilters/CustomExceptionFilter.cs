using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebAPIControllers.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // Log the exception to the console
            Console.WriteLine("Exception Occurred: " + context.Exception.Message);

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