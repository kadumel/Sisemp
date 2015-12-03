using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contexto.Models
{
    public partial class MOV
    {
        public int CODIGO { get; set; }
        public int SEQUENCIAL { get; set; }
        [Required(ErrorMessage = "Aplicação deve ser informado!!!")]
        public int APL_CODIGO { get; set; }
        public System.DateTime DATA { get; set; }
        [Required(ErrorMessage = "Aplicação deve ser informado!!!")]
        public double VALOR_TOTAL { get; set; }
        [Required(ErrorMessage = "Aplicação deve ser informado!!!")]
        public Nullable<double> VALOR_REC { get; set; }
        public string OBS { get; set; }
        [Required(ErrorMessage = "Aplicação deve ser informado!!!")]
        public string TIPO { get; set; }
        public virtual APL APL { get; set; }
    }
}
