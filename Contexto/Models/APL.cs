using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contexto.Models
{
    public partial class APL
    {
        public APL()
        {
            this.MOVs = new List<MOV>();
        }

        public int CODIGO { get; set; }
      
        public int CLI_CODIGO { get; set; }
    
        public int EMP_CODIGO { get; set; }
        public Nullable<System.DateTime> DATA { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatorio!!!")]
        public Nullable<double> TAXA { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatorio!!!")]
        public Nullable<double> VALOR { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatorio!!!")]
        public Nullable<int> QTDE { get; set; }
        [Required(ErrorMessage = "Data obrigatoria!!!")]
        public Nullable<System.DateTime> DTBASE { get; set; }
      
        public string PAGT { get; set; }
        [Required(ErrorMessage = "Retorno deve ser calculado!!!")]
        public Nullable<double> VL_LUCRO { get; set; }
        public virtual CLI CLI { get; set; }
        public virtual EMP EMP { get; set; }
        public virtual ICollection<MOV> MOVs { get; set; }
    }
}
