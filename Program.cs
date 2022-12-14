using TechnicalTask.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IEmployeesDataAccess, EmployeesDataAccess>();
builder.Services.AddTransient<IAddressesDataAccess, AddressesDataAccess>();
builder.Services.AddTransient<IPositionsDataAccess, PositionsDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");*/

app.MapFallbackToFile("index.html");
;

app.Run();