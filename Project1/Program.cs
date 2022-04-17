using Project1.Models;
using Microsoft.EntityFrameworkCore;
using Project1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.Configure<CarItemsDatabaseSettings>(
    builder.Configuration.GetSection("CarItemsDatabase"));
builder.Services.AddSingleton<CarsService>();
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
