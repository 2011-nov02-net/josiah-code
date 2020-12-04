using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloAspNet
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/{path}", async context =>
                {
                    string path = (string)context.Request.RouteValues["path"];
                    try
                    {
                        await context.Response.WriteAsync(await File.ReadAllTextAsync(path));
                    }
                    catch (FileNotFoundException)
                    {
                        //await context.Response.WriteAsync("Done goofed");
                    }
                });

                endpoints.MapControllerRoute(
                    name: "hello-controller",
                    pattern: "hello",
                    defaults: new { controller = "Hello", action = "Action1"});

                endpoints.MapControllerRoute(
                    name: "hello-contoller2",
                    pattern: "hello/{p1}/{p2}",
                    defaults: new { controller = "Hello", action = "ParameterizedAction" });
            });

            app.Run(async context =>
            {

                HttpRequest request = context.Request;

                HttpResponse response = context.Response;


                response.ContentType = "text/html";
                await response.WriteAsync(@"<!DOCTYPE html>
<html>
    <head>
    </head>
    <body>
        Hello World!
    </body>
</html>");
            });
        }
    }
}