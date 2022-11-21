using Cone.InventoryManagement.Web.Contracts.Persistence;
using Cone.InventoryManagement.Web.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Web.Services;
using Cone.InventoryManagement.Web.Services.Base;
using Cone.InventoryManagement.Web.Services.Clients;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IClient, Client>(options => options.BaseAddress = new Uri("https://localhost:7245"));
// Register Automapper service
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Register Services and Interfaces
builder.Services.AddScoped<IClientSetupService, ClientSetupService>();
builder.Services.AddScoped<IClientConnectionService, ClientConnectionService>();

// 
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

//By default system includes appsettings.json and it can be accessed in controller classes.
//To access in static method
//The solution is to inject IConfiguration at run time using ServiceProviderServiceExtensions.GetRequiredService Method. 
//Where UtilityHelper.AppSettingsConfigure is the static class name 
//UtilityHelper.AppSettingsConfigure(app.Services.GetRequiredService<IConfiguration>());


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
    pattern: "{controller=ClientSetup}/{action=Index}/{id?}");

app.Run();
