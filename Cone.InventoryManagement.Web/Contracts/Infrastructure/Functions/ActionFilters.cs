using Cone.InventoryManagement.Web.Services.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Web.Contracts.Infrastructure.Functions
{
    public class ActionFilters
    {
        //https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-7.0

        //Filters in ASP.NET Core allow code to run before or after specific stages in the request processing pipeline.

        //Built-in filters handle tasks such as:


        //Authorization, preventing access to resources a user isn't authorized for.

        //Response caching, short-circuiting the request pipeline to return a cached response.

        //Custom filters can be created to handle cross-cutting concerns. Examples of cross-cutting concerns include error handling, 
        //caching, configuration, authorization, and logging. Filters avoid duplicating code. For example, an error handling exception 
        //filter could consolidate error handling.
    }
}
