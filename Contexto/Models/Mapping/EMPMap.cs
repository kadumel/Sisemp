using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contexto.Models.Mapping
{
    public class EMPMap : EntityTypeConfiguration<EMP>
    {
        public EMPMap()
        {
            // Primary Key
            this.HasKey(t => t.CODIGO);

            // Properties
            this.Property(t => t.NOME)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.RAZAOSOCIAL)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("EMP");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.NOME).HasColumnName("NOME");
            this.Property(t => t.RAZAOSOCIAL).HasColumnName("RAZAOSOCIAL");
        }
    }
}
