using ConsoleToWebAppCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore
{
    public class Startup
    {
        //Configure and Inject services
        public void ConfigureServices(IServiceCollection services)
        {
            //only API injection Services.AddMVC()-->For both WebAPP and API
            services.AddControllers();
            services.AddTransient<CustomMiddleWare>();
            //services.AddTransient<IProductRepository, TestRepository>();
            //services.AddTransient<IProductRepository, ProductRepository>();
            services.TryAddTransient<IProductRepository, TestRepository>();
            services.TryAddTransient<IProductRepository, ProductRepository>();
        }

        //HTTP request/response Middlewares
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("This is from Use 1-1\n");
                await next();
                await context.Response.WriteAsync("This is from Use 1-2 \n");
            });

            app.UseMiddleware<CustomMiddleWare>();
            app.Map("/Suresh", HelloTest);

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("This is from Use 2-1\n");
                await next();
                await context.Response.WriteAsync("This is from Use 2-2 \n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Request complete \n");
            });
            */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello ConsoleToWebApp");
                //});
            });
        }

        private void HelloTest(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello method \n");
            });
        }
    }
}
