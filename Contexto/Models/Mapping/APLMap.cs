using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contexto.Models.Mapping
{
    public class APLMap : EntityTypeConfiguration<APL>
    {
        public APLMap()
        {
            // Primary Key
            this.HasKey(t => t.CODIGO);

            // Properties
            // Table & Column Mappings
            this.ToTable("APL");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.CLI_CODIGO).HasColumnName("CLI_CODIGO");
            this.Property(t => t.EMP_CODIGO).HasColumnName("EMP_CODIGO");
            this.Property(t => t.DATA).HasColumnName("DATA");
            this.Property(t => t.TAXA).HasColumnName("TAXA");
            this.Property(t => t.VALOR).HasColumnName("VALOR");
            this.Property(t => t.QTDE).HasColumnName("QTDE");
            this.Property(t => t.DTBASE).HasColumnName("DTBASE");

            // Relationships
            this.HasRequired(t => t.CLI)
                .WithMany(t => t.APLs)
                .HasForeignKey(d => d.CLI_CODIGO);
            this.HasRequired(t => t.EMP)
                .WithMany(t => t.APLs)
                .HasForeignKey(d => d.EMP_CODIGO);

        }
    }
}
