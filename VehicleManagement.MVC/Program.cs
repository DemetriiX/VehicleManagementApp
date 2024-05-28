using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using VehicleManagement.MVC;
using VehicleManagement.Service.Data;
using VehicleManagement.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VehicleContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("VehicleContext"));
});
builder.Services.AddScoped<IVehicleMakeService, VehicleManagement.Service.Services.VehicleMakeService>();
builder.Services.AddScoped<IVehicleModelService, VehicleManagement.Service.Services.VehicleModelService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new NinjectServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
