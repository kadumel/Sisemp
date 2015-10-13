using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contexto.Models.Mapping
{
    public class RDMMap : EntityTypeConfiguration<RDM>
    {
        public RDMMap()
        {
            // Primary Key
            this.HasKey(t => t.CODIGO);

            // Properties
            this.Property(t => t.CODIGO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("RDM");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.MOV_CODIGO).HasColumnName("MOV_CODIGO");
            this.Property(t => t.CRD_CODIGO).HasColumnName("CRD_CODIGO");
            this.Property(t => t.VALOR).HasColumnName("VALOR");

            // Relationships
            this.HasRequired(t => t.CRD)
                .WithMany(t => t.RDMs)
                .HasForeignKey(d => d.CRD_CODIGO);
            this.HasRequired(t => t.MOV)
                .WithMany(t => t.RDMs)
                .HasForeignKey(d => d.MOV_CODIGO);

        }
    }
}
