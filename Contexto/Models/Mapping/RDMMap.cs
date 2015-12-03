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
            // Table & Column Mappings
            this.ToTable("RDM");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.ROT_CODIGO).HasColumnName("ROT_CODIGO");
            this.Property(t => t.CRD_CODIGO).HasColumnName("CRD_CODIGO");
            this.Property(t => t.VALOR).HasColumnName("VALOR");
            this.Property(t => t.DATA).HasColumnName("DATA");

            // Relationships
            this.HasRequired(t => t.CRD)
                .WithMany(t => t.RDMs)
                .HasForeignKey(d => d.CRD_CODIGO);
            this.HasOptional(t => t.ROT)
                .WithMany(t => t.RDMs)
                .HasForeignKey(d => d.ROT_CODIGO);

        }
    }
}
