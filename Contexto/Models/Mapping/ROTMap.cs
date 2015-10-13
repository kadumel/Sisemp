using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contexto.Models.Mapping
{
    public class ROTMap : EntityTypeConfiguration<ROT>
    {
        public ROTMap()
        {
            // Primary Key
            this.HasKey(t => t.CODIGO);

            // Properties
            this.Property(t => t.CODIGO)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NOME)
                .IsFixedLength()
                .HasMaxLength(40);

            this.Property(t => t.MOTBOY)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ROT");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.NOME).HasColumnName("NOME");
            this.Property(t => t.MOTBOY).HasColumnName("MOTBOY");
        }
    }
}
