using Microsoft.EntityFrameworkCore;
using Orcamentaria.ServiceName.Domain.Models;
using Orcamentaria.ServiceName.Infrastructure.Configurations;

namespace Orcamentaria.ServiceName.Infrastructure.Contexts
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options)
        : base(options)
        {
        }

        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExampleConfiguration());
        }
    }
}
