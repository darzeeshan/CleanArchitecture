using Cone.InventoryManagement.Api.Models;
using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace Cone.InventoryManagement.Api.Extensions
{
    public static class ServiceExtensions
    {
        //This handles the global exceptions (try / catch)
        public static void ConfigureExceptionHanlder(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options => {
                options.Run(async context => {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeatures != null)
                    {
                        Log.Error($"{contextFeatures.Error}");

                        await context.Response.WriteAsync(new GlobalException
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = Messages.Info(10)
                        }.ToString());
                    }
                });
            });
        }
    }
}
