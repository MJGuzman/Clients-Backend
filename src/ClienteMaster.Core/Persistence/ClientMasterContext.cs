using ClientMaster.Core.Framework.EntityConfiguration;
using ClientMaster.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientMaster.Core.Persistence
{
    public class ClientMasterContext : DbContext
    {
        public ClientMasterContext(DbContextOptions<ClientMasterContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SectorConfiguration());
            modelBuilder.ApplyConfiguration(new MunicipalityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Sector> Sectors { get; set; }

    }
}
