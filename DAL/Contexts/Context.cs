using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DAL.Configurations;

namespace DAL.Contexts
{
    public sealed class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyProductionConfiguration());
            modelBuilder.ApplyConfiguration(new ConcernConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionConfiguration());
        }

    }

}
