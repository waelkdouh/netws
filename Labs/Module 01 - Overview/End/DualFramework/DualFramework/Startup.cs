using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DualFramework
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 200;

                #if NET462
                await context.Response.WriteAsync("<h1>ASP.NET Core on .NET Framework</h1>");

                #else
                await context.Response.WriteAsync("<h1>ASP.NET Core on .NET Core</h1>");

                #endif
                await context.Response.WriteAsync("<h2>Server Time</h2>");
                await context.Response.WriteAsync($"Server time is {DateTime.Now}");
            });
        }


    }
}
