using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace WebApplication
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appsettings.json")
                                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Router
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet("post/{postNumber:int}", context => 
                    context.Response.WriteAsync($"Blog post id : {context.GetRouteValue("postNumber")}"));

            routeBuilder.MapGet("post/{postNumber}", context =>
                    context.Response.WriteAsync($"Blog post string : {context.GetRouteValue("postNumber")}"));

            routeBuilder.MapGet("", context => context.Response.WriteAsync("Hello from Routing"));
            routeBuilder.MapGet("maria", context => context.Response.WriteAsync("Hello from Maria's Routing"));
            routeBuilder.MapGet("scott/foo", context => context.Response.WriteAsync("Hello from Scott's Routing"));

            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(MariaLib.Class1.Greeting());
            });

        }
    }
}
