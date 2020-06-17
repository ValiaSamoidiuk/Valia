using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class CompanyProductionConfiguration : IEntityTypeConfiguration<CompanyProduction>
    {
        public void Configure(EntityTypeBuilder<CompanyProduction> builder)
        {
            builder.ToTable("CompanyProductions");

            builder.HasIndex(a => a.Id)
                .IsUnique();

            builder.HasOne(r => r.Company)
                .WithMany(s => s.CompanyProductions)
                .HasForeignKey(a => a.CompanyId);

            builder.HasOne(r => r.Production)
                .WithMany()
                .HasForeignKey(a => a.ProductionId);
        }
    }
}