using Northwind.web;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
}).Build().Run();
/*if (!app.Environment.IsDevelopment())
{
    //app.UseHsts();
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.MapGet("/", () => "Hello World!");

app.Run();
*/
Console.WriteLine("�� ������ �����Ǹ� �� �ؽ�Ʈ�� ��� ��");