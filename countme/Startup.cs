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
            int SumOfNumbers = 0;
            object postObject = new object();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/", async context =>
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.Body))
                    {
                        string strInput = await (sr.ReadToEndAsync());
                        int intInput = Convert.ToInt32(strInput);
                        // System.Threading.Interlocked.Add(ref SumOfNumbers, intInput);
                        lock (postObject)
                        {
                            SumOfNumbers = SumOfNumbers + intInput;
                        }
                        await context.Response.CompleteAsync();
                    }
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
