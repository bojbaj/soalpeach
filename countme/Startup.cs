using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CountMe
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            decimal SumOfNumbers = 0;
            object postObject = new object();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/", async context =>
                {
                    decimal decInput = 0;
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.Body))
                    {
                        string strInput = await (sr.ReadToEndAsync());
                        decInput = Convert.ToDecimal(strInput);
                    }
                    lock (postObject)
                    {
                        SumOfNumbers = SumOfNumbers + decInput;
                    }
                    await context.Response.CompleteAsync();
                });

                endpoints.MapGet("/count", async context =>
                {
                    await context.Response.WriteAsync(SumOfNumbers.ToString());
                    await context.Response.CompleteAsync();                    
                });

                endpoints.MapGet("/reset", async context =>
                {
                    SumOfNumbers = 0;
                    await context.Response.CompleteAsync();
                });
            });
        }
    }
}
