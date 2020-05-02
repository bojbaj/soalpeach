using System;
using CountMe.Helpers;
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
            // Db db = new Db();             
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/", async context =>
                {
                    using(System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.Body))
                    {
                        string strInput = await (sr.ReadToEndAsync());                        
                        // int input = Convert.ToInt32(strInput);                    
                        // await db.SetNewNumber(input);
                        SumOfNumbers += Convert.ToInt32(strInput);
                    }
                    await context.Response.CompleteAsync();
                    
                });
                endpoints.MapGet("/count", async context =>
                {
                    // string result = (await db.GetSumOfNumbers()).ToString();
                    await context.Response.WriteAsync(SumOfNumbers.ToString());
                    await context.Response.CompleteAsync();
                });
            });
        }
    }
}
