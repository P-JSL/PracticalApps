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
