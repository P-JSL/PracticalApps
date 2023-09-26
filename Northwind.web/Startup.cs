using static System.Console;
using Packt.Shared;

namespace Northwind.web;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddNorthwindContext();
        services.AddRazorPages();
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if(!env.IsDevelopment())
        {
            app.UseHsts();
        }
        app.UseRouting();
        app.Use(async (HttpContext context, Func<Task> next) =>
        {
            RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
            if (rep is not null)
            {
                WriteLine($"Endpoing name: {rep.DisplayName}");
                WriteLine($"Endpoing route pattern : {rep.RoutePattern.RawText}");
            }
            else
            {
                if(context.Request.Path == "/bonjour")
                {
                    //url 경로가 일치하면 응답을 반환하는 종료 대리자가 되므로
                    //다음 대리자를 호출하지 않음
                    await context.Response.WriteAsync("Bonjour Monde!");
                    return;
                }
            }
            await next();
        });
        app.UseHttpsRedirection();
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapGet("/hello", () => " Hello world");
        });
    }
}
