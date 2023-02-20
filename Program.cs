using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myown.Context;
using myown.Models;
using myown.Context;
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

// public enum Family
// {
//     Boidae,
//     Viperidae,
//     Elapidae,
//     Colubridae,
//     Dipsadidae,
//     Pythonidae
// }



// public class Serpent
// {
//     public int Id { get; set; }
//     public string PopularName { get; set; }
//     public string CientificName { get; set; }
//     public Family Family { get; set; }
// }



// List<Serpent> serpents = new List<Serpent>() {
//     new (1, "surucucu", "Lachesis muta", Family.Viperidae),
//     new (2, "cascavel", "Crotalus durissus", Family.Viperidae),
//     new (3, "jararaca-da-mata", "Bothrops jararaca", Family.Viperidae),
//     new (4, "jararaca-do-norte", "Bothrops atrox", Family.Viperidae),
//     new (5, "jararaca-da-seca", "Bothrops erythromelas", Family.Viperidae),
//     new (6, "jararaca-ilhoa", "Bothrops insularis", Family.Viperidae),
//     new (7, "jararacuçu", "Bothrops jararacussu", Family.Viperidae),
//     new (8, "urutu-cruzeiro", "Bothrops alternatus", Family.Viperidae),
//     new (9, "cobra-coral", "Micrurus ibiboboca", Family.Elapidae),
//     new (10, "cobra-coral", "Micrurus corallinus", Family.Elapidae),
//     new (11, "cobra-coral", "Micrurus albicintus", Family.Elapidae),
//     new (12, "jiboia", "Boa constrictor", Family.Boidae),
//     new (13, "jiboia-arco-íris", "Epicrates assisi", Family.Boidae),
//     new (14, "sucuri-verde", "Eunectes murinus", Family.Boidae),
//     new (15, "sucuri-amarela", "Eunectes notaeus", Family.Boidae),
//     new (16, "píton-reticulada", "Malayopython reticulatus", Family.Pythonidae),
//     new (17, "cobra-rei", "Ophiophagus hannah", Family.Elapidae),
//     new (18, "taipan-do-interior", "Oxyuranus microlepidotus", Family.Elapidae),
//     new (19, "mamba-negra", "Dendroaspis polylepis", Family.Elapidae),
//     new (20, "mamba-verde-oriental", "Dendroaspis angusticeps", Family.Elapidae),
//     new (21, "naja-cuspideira", "Hemachatus haemachatus", Family.Elapidae),
//     new (22, "naja-egípcia", "Naja haje", Family.Elapidae),
//     new (23, "víbora-do-gabão", "Bitis gabonica", Family.Viperidae),
//     new (24, "periquitamboia", "Corallus caninus", Family.Boidae),
//     new (25, "cobra-verde", "Liophis typhlus", Family.Dipsadidae),
//     new (26, "muçurana", "Clelia clelia", Family.Dipsadidae),
//     new (27, "caninana", "Spilotes pullatus", Family.Colubridae),
//     new (28, "cobra-cipó-marrom", "Chironius quadricarinatus", Family.Colubridae)
// };