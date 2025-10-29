using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orcamentaria.ServiceName.Domain.Models;

namespace Orcamentaria.ServiceName.Infrastructure.Configurations
{
    public class ExampleConfiguration : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.ToTable("T_EXAMPLE");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.Name).HasColumnName("NAME");
            builder.Property(p => p.Active).HasColumnName("ACTIVE");
            builder.Property(p => p.OrderId).HasColumnName("ORDER_ID");	
        }
    }
}
