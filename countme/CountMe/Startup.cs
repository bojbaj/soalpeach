using System;
using System.Net;
using System.Net.Http;
using CountMe.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            Db db = new Db();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/", async context =>
               {
                   int input = Convert.ToInt32(new System.IO.StreamReader(context.Request.Body).ReadToEnd());
                   await context.Response.WriteAsync(db.SetNewNumber(input).ToString());
               });
                endpoints.MapGet("/count", async context =>
                {
                    await context.Response.WriteAsync(db.GetSumOfNumbers().ToString());
                });
            });
            db.SetNewNumber(0);
        }
    }
}
