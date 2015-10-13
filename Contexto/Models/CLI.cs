using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contexto.Models
{
    public partial class CLI
    {
        public int CODIGO { get; set; }
        [Required]
        public Nullable<int> EMP_CODIGO { get; set; }
        [Required]
        public string NOME { get; set; }

        public string RAZAOSOCIAL { get; set; }
        [Required]
        public string CPF_CNPJ { get; set; }
        [Required]
        public string END { get; set; }
        public string COMP { get; set; }
        public string CEP { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string TEL { get; set; }
        [Required]
        public string CEL { get; set; }
        public string OBS { get; set; }
    }
}
