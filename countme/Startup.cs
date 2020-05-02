using System;
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
            bool reultGetRequested = false;
            decimal SumOfNumbers = 0;
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/", async context =>
                {
                    if (reultGetRequested)
                    {
                        throw new AggregateException("Request Order Is Wrong");
                    }

                    using (System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.Body))
                    {
                        string strInput = await (sr.ReadToEndAsync());
                        SumOfNumbers += Convert.ToDecimal(strInput);
                    }
                });

                endpoints.MapGet("/count", async context =>
                {
                    reultGetRequested = true;
                    await context.Response.WriteAsync(SumOfNumbers.ToString());
                });

                endpoints.MapGet("/reset", async context =>
                {
                    reultGetRequested = false;
                    SumOfNumbers = 0;
                    await context.Response.CompleteAsync();
                });
            });
        }
    }
}
