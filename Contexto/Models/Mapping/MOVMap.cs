using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contexto.Models.Mapping
{
    public class MOVMap : EntityTypeConfiguration<MOV>
    {
        public MOVMap()
        {
            // Primary Key
            this.HasKey(t => t.CODIGO);

            // Properties
            this.Property(t => t.CODIGO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OBS)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MOV");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.SEQUENCIAL).HasColumnName("SEQUENCIAL");
            this.Property(t => t.APL_CODIGO).HasColumnName("APL_CODIGO");
            this.Property(t => t.ROT_CODIGO).HasColumnName("ROT_CODIGO");
            this.Property(t => t.DATA).HasColumnName("DATA");
            this.Property(t => t.VALOR_TOTAL).HasColumnName("VALOR_TOTAL");
            this.Property(t => t.VALOR_REC).HasColumnName("VALOR_REC");
            this.Property(t => t.OBS).HasColumnName("OBS");

            // Relationships
            this.HasRequired(t => t.APL)
                .WithMany(t => t.MOVs)
                .HasForeignKey(d => d.APL_CODIGO);
            this.HasOptional(t => t.ROT)
                .WithMany(t => t.MOVs)
                .HasForeignKey(d => d.ROT_CODIGO);

        }
    }
}
