using EmployeeSystem.Application.Contracts.ResponseModel;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace EmployeeSystem.Extentions
{
    public static class ExceptionMiddlewareExtention
    {
        public static void ConfigureDefaultExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async httpContext =>
                {
                    var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await HandleExceptionAsync(httpContext, contextFeature.Error);
                    }
                });
            });
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //httpContext.Response.ContentType = "application/json";
            //await httpContext.Response.WriteAsync(new 
            //{
            //    StatusCode = httpContext.Response.StatusCode,
            //    Message = exception.Message
            //}.ToString());

            var message = exception switch
            {
                ArgumentException => "Invalid Body",
                _ => exception.Message//"global exception message"
            };

            await httpContext.Response.WriteAsJsonAsync(new ApiResponseModel()
            {
                Status = false,
                Message = message,
                Data = null
            });
        }
    }
}
