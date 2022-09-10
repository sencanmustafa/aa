using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Concrete.EntityFramework
{
    public class NorhwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sql.athena.domainhizmetleri.com,1433;Database=mustaf11_dotnet;Trusted_Connection=true;Username=mustaf11_dotnet;Password=Mustiler463!");
        }
        public DbSet<Product>? Products { get; set; }

        public DbSet<Category>? Categories { get; set; }
    }
}

