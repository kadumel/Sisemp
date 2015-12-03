using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contexto.Models
{
    public partial class CLI
    {
        public CLI()
        {
            this.APLs = new List<APL>();
        }

        public int CODIGO { get; set; }
        [Required(ErrorMessage = "O nome deve ser informado!!!")]
        public string NOME { get; set; }
        [Required(ErrorMessage = "A razão social deve ser informado!!!")]
        public string RAZAOSOCIAL { get; set; }
        public string CPF_CNPJ { get; set; }
        [Required(ErrorMessage = "O endereço deve ser informado!!!")]
        public string END { get; set; }
        public string COMP { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatorio!!!")]
        public string BAIRRO { get; set; }
        public Nullable<int> ROTA { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string TEL { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatorio!!!")]
        public string CEL { get; set; }
        public string OBS { get; set; }
        public virtual ICollection<APL> APLs { get; set; }
        public virtual ROT ROT { get; set; }
    }
}
