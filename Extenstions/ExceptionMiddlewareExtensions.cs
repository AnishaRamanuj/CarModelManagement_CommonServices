
using CarModelManagement_CommonServices.API.Middlewares;
using Microsoft.AspNetCore.Builder;


namespace CarModelManagement_CommonServices.API.Extensions
{
    /// <summary>
    /// Use Exception Middleware in Startup
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Global exception middleware inject to startup
        /// </summary>
        /// <param name="app"></param>
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}