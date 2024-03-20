using Microsoft.EntityFrameworkCore;
using RestApi.Models;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CRUD}/{action=Get}/{param?}");

app.Run();
