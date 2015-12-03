using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contexto.Models
{
    public partial class RDM
    {
        public int CODIGO { get; set; }
        public Nullable<int> ROT_CODIGO { get; set; }
        public int CRD_CODIGO { get; set; }
        [Required(ErrorMessage = "Valor deve ser informado!!!")]
        public double VALOR { get; set; }
        public System.DateTime DATA { get; set; }
        public virtual CRD CRD { get; set; }
        public virtual ROT ROT { get; set; }
    }
}
