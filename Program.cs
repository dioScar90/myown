using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myown.Context;
using myown.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SerpentContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SerpentContext") ?? throw new InvalidOperationException("Connection string 'SerpentContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

/* To run on CLI:
    dotnet tool uninstall --global dotnet-aspnet-codegenerator
    dotnet tool install --global dotnet-aspnet-codegenerator
    dotnet tool uninstall --global dotnet-ef
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.SQLite
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer

    if (Linux || macOS)
        export PATH=$HOME/.dotnet/tools:$PATH
    
    dotnet aspnet-codegenerator controller -name SerpentsController -m Serpent -dc myown.Context.SerpentContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

    dotnet ef migrations add InitialCreate
    dotnet ef database update
*/