using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myown.Models;

namespace myown.Context
{
    public class SerpentContext : DbContext
    {
        public SerpentContext (DbContextOptions<SerpentContext> options)
            : base(options)
        {
        }

        public DbSet<myown.Models.Serpent> Serpent { get; set; } = default!;
    }
}
