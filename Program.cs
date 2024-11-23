using UniversityApp.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


builder.Services.AddSignalR();
builder.Services.AddDbContext<UniversityContext>();



var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<UniversityHub>("/universityHub");

app.Run();
