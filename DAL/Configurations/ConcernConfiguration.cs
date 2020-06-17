using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class ConcernConfiguration : IEntityTypeConfiguration<Concern>
    {
        public void Configure(EntityTypeBuilder<Concern> builder)
        {
            builder.ToTable("Concerns");

            builder.HasMany(a => a.Companies);
        }
    }
}