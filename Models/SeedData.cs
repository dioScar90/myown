using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Conntext;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}

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