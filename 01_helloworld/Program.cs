﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
    public class Startup 
    {
        public void Configure(IApplicationBuilder app) 
        {
            app.Run(
                context => { 
                    return context.Response.WriteAsync("Hello, World on the web");
                }
            );
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            
            host.Run();
        }
    }
}
