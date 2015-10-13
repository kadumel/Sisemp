using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Contexto.Models.Mapping;

namespace Contexto.Models
{
    public partial class SISEMPContext : DbContext
    {
        static SISEMPContext()
        {
            Database.SetInitializer<SISEMPContext>(null);
        }

        public SISEMPContext()
            : base("Name=SISEMPContext")
        {
        }

        public DbSet<APL> APLs { get; set; }
        public DbSet<CLI> CLIs { get; set; }
        public DbSet<CRD> CRDs { get; set; }
        public DbSet<EMP> EMPs { get; set; }
        public DbSet<MOV> MOVs { get; set; }
        public DbSet<RDM> RDMs { get; set; }
        public DbSet<ROT> ROTs { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new APLMap());
            modelBuilder.Configurations.Add(new CLIMap());
            modelBuilder.Configurations.Add(new CRDMap());
            modelBuilder.Configurations.Add(new EMPMap());
            modelBuilder.Configurations.Add(new MOVMap());
            modelBuilder.Configurations.Add(new RDMMap());
            modelBuilder.Configurations.Add(new ROTMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
