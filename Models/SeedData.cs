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
        Serpent[] serpentsThatHaveToBeListed = new Serpent[]
        {
            new()
            {
                PopularName = "Surucucu",
                CientificName = "Lachesis muta",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Cascavel",
                CientificName = "Crotalus durissus",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Jararaca-da-mata",
                CientificName = "Bothrops jararaca",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Jararaca-do-norte",
                CientificName = "Bothrops atrox",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Jararaca-da-seca",
                CientificName = "Bothrops erythromelas",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Jararaca-ilhoa",
                CientificName = "Bothrops insularis",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Jararacuçu",
                CientificName = "Bothrops jararacussu",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Urutu-cruzeiro",
                CientificName = "Bothrops alternatus",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Cobra-coral (Caatinga)",
                CientificName = "Micrurus ibiboboca",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Cobra-coral (Mata Atlântica)",
                CientificName = "Micrurus corallinus",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Cobra-coral (Amazônia)",
                CientificName = "Micrurus albicintus",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Jiboia",
                CientificName = "Boa constrictor",
                FamilyType = Family.Boidae
            },
            new()
            {
                PopularName = "Jiboia-arco-íris",
                CientificName = "Epicrates assisi",
                FamilyType = Family.Boidae
            },
            new()
            {
                PopularName = "Sucuri-verde",
                CientificName = "Eunectes murinus",
                FamilyType = Family.Boidae
            },
            new()
            {
                PopularName = "Sucuri-amarela",
                CientificName = "Eunectes notaeus",
                FamilyType = Family.Boidae
            },
            new()
            {
                PopularName = "Píton-reticulada",
                CientificName = "Malayopython reticulatus",
                FamilyType = Family.Pythonidae
            },
            new()
            {
                PopularName = "Cobra-rei",
                CientificName = "Ophiophagus hannah",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Taipan-do-interior",
                CientificName = "Oxyuranus microlepidotus",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Mamba-negra",
                CientificName = "Dendroaspis polylepis",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Mamba-verde-oriental",
                CientificName = "Dendroaspis angusticeps",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Naja-cuspideira",
                CientificName = "Hemachatus haemachatus",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Naja-egípcia",
                CientificName = "Naja haje",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Víbora-do-gabão",
                CientificName = "Bitis gabonica",
                FamilyType = Family.Viperidae
            },
            new()
            {
                PopularName = "Periquitamboia",
                CientificName = "Corallus caninus",
                FamilyType = Family.Boidae
            },
            new()
            {
                PopularName = "Cobra-verde",
                CientificName = "Liophis typhlus",
                FamilyType = Family.Dipsadidae
            },
            new()
            {
                PopularName = "Muçurana",
                CientificName = "Clelia clelia",
                FamilyType = Family.Dipsadidae
            },
            new()
            {
                PopularName = "Caninana",
                CientificName = "Spilotes pullatus",
                FamilyType = Family.Colubridae
            },
            new()
            {
                PopularName = "Cobra-cipó-marrom",
                CientificName = "Chironius quadricarinatus",
                FamilyType = Family.Colubridae
            },
            new()
            {
                PopularName = "Jararacuçu-do-brejo",
                CientificName = "Palusophis bifossatus",
                FamilyType = Family.Colubridae
            },
            new()
            {
                PopularName = "Titanoboa",
                CientificName = "Titanoboa cerrejonensis",
                FamilyType = Family.Boidae
            },
            new()
            {
                PopularName = "Cobra-cipó-verde",
                CientificName = "Chironius bicarinatus",
                FamilyType = Family.Colubridae
            },
            new()
            {
                PopularName = "Suaçuboia",
                CientificName = "Corallus hortulanus",
                FamilyType = Family.Boidae
            },
            new()
            {
                PopularName = "Cobra d'água",
                CientificName = "Helicops angulatus",
                FamilyType = Family.Colubridae
            },
            new()
            {
                PopularName = "Naja-indiana",
                CientificName = "Naja naja",
                FamilyType = Family.Elapidae
            },
            new()
            {
                PopularName = "Cobra-verde",
                CientificName = "Philodryas olfersii",
                FamilyType = Family.Colubridae
            }
        };
        using (var context = new SerpentContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<SerpentContext>>()))
        {
            List<Serpent> serpentsAlreadyListed = context.Serpent.ToList();
            
            // Look for any movies.
            if (context.Serpent.Any())
            {
                List<Serpent> serpentsToAdd = serpentsThatHaveToBeListed.Where(s => !serpentsAlreadyListed.Any(tl => tl.CientificName == s.CientificName)).ToList();
                if (serpentsToAdd.Any()) {
                    Console.WriteLine("\n\n\nAdicionou\n\n\n");
                    context.Serpent.AddRange(serpentsToAdd);
                    context.SaveChanges();
                    Console.WriteLine("\n\n\nAdicionou MESMO!\n\n\n");
                }
                return;   // DB has been seeded
            }
            
            context.Serpent.AddRange(serpentsThatHaveToBeListed);
            context.SaveChanges();
        }
    }
}