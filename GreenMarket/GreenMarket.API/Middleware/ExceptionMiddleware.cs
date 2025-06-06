using Microsoft.AspNetCore.Diagnostics;

namespace GreenMarket.API.Middleware
{
    public static class ExceptionMiddleware
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    var statusCode = exception switch
                    {
                        FluentValidation.ValidationException => StatusCodes.Status400BadRequest,
                        UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    context.Response.StatusCode = statusCode;

                    var response = new
                    {
                        status = statusCode,
                        error = exception?.GetType().Name,
                        message = exception?.Message,
                    };

                    await context.Response.WriteAsJsonAsync(response);
                });
            });

            return app;
        }
    }

}
