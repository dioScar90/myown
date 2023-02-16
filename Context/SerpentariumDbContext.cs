using Microsoft.EntityFrameworkCore;
using myown.Models;

namespace myown.Context;

public class SerpentariumDbContext
{
    public List<Serpent> Serpents { get; set; }
    public SerpentariumDbContext()
    {
        Serpents = new List<Serpent>();
    }
}

// public class SerpentContext : DbContext
// {
//     public SerpentContext(DbContextOptions<SerpentContext> options) : base(options)
//     {

//     }

//     public DbSet<Serpent> Serpents { get; set; }
// }