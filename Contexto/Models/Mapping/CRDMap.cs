using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contexto.Models.Mapping
{
    public class CRDMap : EntityTypeConfiguration<CRD>
    {
        public CRDMap()
        {
            // Primary Key
            this.HasKey(t => t.CODIGO);

            // Properties
            this.Property(t => t.NOME)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("CRD");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.CODIGO_PAI).HasColumnName("CODIGO_PAI");
            this.Property(t => t.NOME).HasColumnName("NOME");
        }
    }
}
