using Microsoft.EntityFrameworkCore;
using myown.Models;

namespace myown.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        {}
        public DbSet<MyData> MyDatas { get; set; }
        // public DbSet<Post> Posts { get; set; }
    }
}