using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myown.Context;
using System;
using System.Linq;

namespace myown.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SerpentContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<SerpentContext>>()))
        {
            // Look for any movies.
            if (context.Serpent.Any())
            {
                return;   // DB has been seeded
            }
            context.Serpent.AddRange(
                new Serpent
                {
                    PopularName = "Surucucu",
                    CientificName = "Lachesis muta",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Cascavel",
                    CientificName = "Crotalus durissus",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Jararaca-da-mata",
                    CientificName = "Bothrops jararaca",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Jararaca-do-norte",
                    CientificName = "Bothrops atrox",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Jararaca-da-seca",
                    CientificName = "Bothrops erythromelas",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Jararaca-ilhoa",
                    CientificName = "Bothrops insularis",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Jararacuçu",
                    CientificName = "Bothrops jararacussu",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Urutu-cruzeiro",
                    CientificName = "Bothrops alternatus",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Cobra-coral (Caatinga)",
                    CientificName = "Micrurus ibiboboca",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Cobra-coral (Mata Atlântica)",
                    CientificName = "Micrurus corallinus",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Cobra-coral (Amazônia)",
                    CientificName = "Micrurus albicintus",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Jiboia",
                    CientificName = "Boa constrictor",
                    FamilyType = Family.Boidae
                },
                new Serpent
                {
                    PopularName = "Jiboia-arco-íris",
                    CientificName = "Epicrates assisi",
                    FamilyType = Family.Boidae
                },
                new Serpent
                {
                    PopularName = "Sucuri-verde",
                    CientificName = "Eunectes murinus",
                    FamilyType = Family.Boidae
                },
                new Serpent
                {
                    PopularName = "Sucuri-amarela",
                    CientificName = "Eunectes notaeus",
                    FamilyType = Family.Boidae
                },
                new Serpent
                {
                    PopularName = "Píton-reticulada",
                    CientificName = "Malayopython reticulatus",
                    FamilyType = Family.Pythonidae
                },
                new Serpent
                {
                    PopularName = "Cobra-rei",
                    CientificName = "Ophiophagus hannah",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Taipan-do-interior",
                    CientificName = "Oxyuranus microlepidotus",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Mamba-negra",
                    CientificName = "Dendroaspis polylepis",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Mamba-verde-oriental",
                    CientificName = "Dendroaspis angusticeps",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Naja-cuspideira",
                    CientificName = "Hemachatus haemachatus",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Naja-egípcia",
                    CientificName = "Naja haje",
                    FamilyType = Family.Elapidae
                },
                new Serpent
                {
                    PopularName = "Víbora-do-gabão",
                    CientificName = "Bitis gabonica",
                    FamilyType = Family.Viperidae
                },
                new Serpent
                {
                    PopularName = "Periquitamboia",
                    CientificName = "Corallus caninus",
                    FamilyType = Family.Boidae
                },
                new Serpent
                {
                    PopularName = "Cobra-verde",
                    CientificName = "Liophis typhlus",
                    FamilyType = Family.Dipsadidae
                },
                new Serpent
                {
                    PopularName = "Muçurana",
                    CientificName = "Clelia clelia",
                    FamilyType = Family.Dipsadidae
                },
                new Serpent
                {
                    PopularName = "Caninana",
                    CientificName = "Spilotes pullatus",
                    FamilyType = Family.Colubridae
                },
                new Serpent
                {
                    PopularName = "Cobra-cipó-marrom",
                    CientificName = "Chironius quadricarinatus",
                    FamilyType = Family.Colubridae
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