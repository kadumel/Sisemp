using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contexto.Models.Mapping
{
    public class CLIMap : EntityTypeConfiguration<CLI>
    {
        public CLIMap()
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

            this.Property(t => t.CPF_CNPJ)
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.END)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.COMP)
                .IsFixedLength()
                .HasMaxLength(40);

            this.Property(t => t.CEP)
                .IsFixedLength()
                .HasMaxLength(9);

            this.Property(t => t.BAIRRO)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.CIDADE)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.UF)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.TEL)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.CEL)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.OBS)
                .IsFixedLength()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("CLI");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.EMP_CODIGO).HasColumnName("EMP_CODIGO");
            this.Property(t => t.NOME).HasColumnName("NOME");
            this.Property(t => t.RAZAOSOCIAL).HasColumnName("RAZAOSOCIAL");
            this.Property(t => t.CPF_CNPJ).HasColumnName("CPF-CNPJ");
            this.Property(t => t.END).HasColumnName("END");
            this.Property(t => t.COMP).HasColumnName("COMP");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.BAIRRO).HasColumnName("BAIRRO");
            this.Property(t => t.CIDADE).HasColumnName("CIDADE");
            this.Property(t => t.UF).HasColumnName("UF");
            this.Property(t => t.TEL).HasColumnName("TEL");
            this.Property(t => t.CEL).HasColumnName("CEL");
            this.Property(t => t.OBS).HasColumnName("OBS");
        }
    }
}
